using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    int spawnposx;
    int spawnposy;
    int spawnforce;
    GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //spawning ball
        spawnposx = Random.Range(-10, 10);
        spawnposy = Random.Range(0, 1);
        Vector3 position = new Vector3(spawnposx, spawnposy, 0);
        Vector2 direction = new Vector2(100, 0);
        gameObject.transform.position = position;

        spawnforce = Random.Range(1, 2);
        if (spawnforce == 1)
            rb.AddForce(direction);
        else if (spawnforce == 2)
            rb.AddForce(-direction);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bullet(Clone)")
            Destroy(gameObject);
    }

}
