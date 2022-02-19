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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(forcepower, 0);
        force3 = new Vector3(forcepower, 0, 0);
        //slide = new Vector2(0, -10*forcepower);
        Vector3 position = new Vector3(0, 0, 0);
        gameObject.transform.position = position;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        void Shoot()
        {
            Instantiate(bullet, shootpoint.position, shootpoint.rotation);
        }
        ShowHearts();
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
        if (collision.name == "Ball(Clone)")
            hearts -= 1;
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
    }

    
}
