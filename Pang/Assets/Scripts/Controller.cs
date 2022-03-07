using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public float forcepower;
    Vector2 slide, jump, force; //chyba niepotrzebne
    Vector3 force3;
    public Transform shootpoint, shootpoint1, shootpoint2;
    public GameObject bullet, harpoon, laser;
    public int hearts = 3;
    public GameObject heart1, heart2, heart3;
    bool isClimbing, isLadder;
    float vertical; //tak samo
    float ladderSpeed = 8;
    public GameObject OnDestroyPanel;
    public Sprite[] Costume;
    public SpriteRenderer CostumeRenderer;
    bool isShooting = false; //boole byly wyzej
    public string weapon;

    void Start()
    {
        //do poruszania siê, zmienne
        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(forcepower, 0);
        force3 = new Vector3(0.2f, 0, 0);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        isShooting = false;
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        //strzelanie
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        void Shoot()
        {
            if (weapon == "singleGun")
                Instantiate(bullet, shootpoint.position, shootpoint.rotation);
            else if (weapon == "doubleGun")
            {
                Instantiate(bullet, shootpoint1.position, shootpoint1.rotation);
                Instantiate(bullet, shootpoint2.position, shootpoint2.rotation);
            }
            else if (weapon == "harpoon")
            {
                Instantiate(harpoon, shootpoint.position, harpoon.transform.rotation);
            } 
            else if (weapon == "laser")
            {
                Instantiate(laser, shootpoint.position, laser.transform.rotation);
            }
            isShooting = true;
            StartCoroutine(Wait());
        }
        ShowHearts();

        //dla drabiny
        if (isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }

    //pokazywanie serc
    void ShowHearts()
    {
        if (hearts == 2)
            Destroy(heart3);
        else if (hearts == 1)
            Destroy(heart2);
        else if (hearts == 0)
        {
            Destroy(gameObject);
            OnDestroyPanel.SetActive(true);
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball1") || collision.CompareTag("Ball2") || collision.CompareTag("Ball3") || collision.CompareTag("Ball4"))
        {
            hearts -= 1;
        }

        //dla drabiny
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    //dla drabiny
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
            isLadder = false;
        }
    }

    void FixedUpdate()
    {
        //sterowanie
        if (Input.GetKey(KeyCode.D))
        {
            CostumeRenderer.sprite = Costume[0];
            CostumeRenderer.flipX = false;
            gameObject.transform.position += force3;
            //rb.AddForce(force);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CostumeRenderer.sprite = Costume[0];
            CostumeRenderer.flipX = true;
            gameObject.transform.position -= force3;
            //rb.AddForce(-force);
        }
        else if (CostumeRenderer.flipX && !isShooting)
            CostumeRenderer.sprite = Costume[1];
        else if (!CostumeRenderer.flipX && !isShooting)
            CostumeRenderer.sprite = Costume[1];
        else if (CostumeRenderer.flipX && isShooting)
            CostumeRenderer.sprite = Costume[2];
        else if (!CostumeRenderer.flipX && isShooting)
            CostumeRenderer.sprite = Costume[2];


        //dla drabiny
        if (isClimbing)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, vertical * ladderSpeed);
        }
        else
        {
            rb.gravityScale = 2;
        }
    }
}
