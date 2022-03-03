using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    int spawnforce;
    public GameObject[] smallerball;
    Vector2 smallerballforce;
    Points value;

    void Start()
    {
        value = GameObject.Find("MapUI").GetComponent<Points>();
        rb = GetComponent<Rigidbody2D>();
        if(gameObject.name == "1(Clone)" || gameObject.name == "0(Clone)")
        {
            //spawning as child
            smallerballforce = new Vector2(200, 0);
            if (gameObject.name == "0(Clone)")
                rb.AddForce(smallerballforce);
            if (gameObject.name == "1(Clone)")
               rb.AddForce(-smallerballforce);
        }
        else
        {
            //spawning ball
            Vector2 direction = new Vector2(100, 0);
            spawnforce = Random.Range(1, 2);
            if (spawnforce == 1)
                rb.AddForce(direction);
            else if (spawnforce == 2)
                rb.AddForce(-direction);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Ball1"))
            value.points += 200;
        else if (gameObject.CompareTag("Ball2"))
            value.points += 150;
        else if (gameObject.CompareTag("Ball3"))
            value.points += 100;
        else if (gameObject.CompareTag("Ball4"))
            value.points += 50;

        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            if (CompareTag("Ball1") == false)
            {
                for (int i = 0; i < 2; i++)
                {
                    Instantiate<GameObject>(smallerball[i], gameObject.transform.position, gameObject.transform.rotation);
                    smallerball[i].name = i.ToString();
                }
            }
        }
        else if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
