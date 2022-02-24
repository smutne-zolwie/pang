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
    int hearts = 3;
    public GameObject heart3;
    public GameObject heart2;
    public GameObject heart1;
    public SpriteMask blackheart;
    bool isClimbing;
    bool isLadder;
    float vertical;
    float ladderSpeed = 8;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(forcepower, 0);
        force3 = new Vector3(forcepower, 0, 0);
        //slide = new Vector2(0, -10*forcepower);
    }

    void Update()
    {
        /*if (Input.GetKey(KeyCode.D))
        {          
            rb.AddForce(force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-force);
        }*/
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        void Shoot()
        {
            Instantiate(bullet, shootpoint.position, shootpoint.rotation);
        }
        ShowHearts();

        if (isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }

    void ShowHearts()
    {
        if (hearts == 2)
            Destroy(heart3);
        else if (hearts == 1)
            Destroy(heart2);
        else if (hearts == 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") || collision.CompareTag("Ball1"))
        {
            hearts -= 1;
        }

        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
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
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += force3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= force3;
        }

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
