using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    public float forcepower;
    Vector2 slide, jump, force;
    Vector3 force3;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(forcepower, 0);
        force3 = new Vector3(forcepower, 0, 0);
        GameObject player;
        //slide = new Vector2(0, -10*forcepower);
    }

    // Update is called once per frame

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

        /*if (rb.velocity.x > 1 && Input.GetKey(KeyCode.A))
            force *= 1.001f;
        else if (rb.velocity.x < -1 && Input.GetKey(KeyCode.D))
            force *= 1.001f;*/
    }
}
