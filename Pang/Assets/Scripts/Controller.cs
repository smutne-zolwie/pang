using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public float forcepower;
    Vector2 slide, jump, force;
    Vector3 force3;
    public Transform shootpoint;
    public GameObject bullet;
    public int hearts = 3;
    public GameObject heart3;
    public GameObject heart2;
    public GameObject heart1;
    public SpriteMask blackheart;
    bool isClimbing;
    bool isLadder;
    float vertical;
    float ladderSpeed = 8;
    public GameObject OnDestroyPanel;

    void Start()
    {
        //do poruszania siê, zmienne
        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(forcepower, 0);
        force3 = new Vector3(forcepower, 0, 0);
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
            Instantiate(bullet, shootpoint.position, shootpoint.rotation);
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
            gameObject.transform.position += force3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= force3;
        }

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
