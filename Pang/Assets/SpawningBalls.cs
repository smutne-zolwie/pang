using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBalls : MonoBehaviour
{
    Rigidbody2D rb;
    int spawnposx;
    int spawnposy;
    int spawnforce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Instantiate - clone object
        spawnposx = Random.Range(-10, 10);
        spawnposy = Random.Range(0, 1);
        
        Vector2 position = new Vector2(spawnposx, spawnposy);
        gameObject.transform.position = position;

        Vector2 direction = new Vector2(100, 0);

        spawnforce = Random.Range(1, 2);
        if (spawnforce == 1)
            rb.AddForce(direction);
        else if (spawnforce == 2)
            rb.AddForce(-direction);
    }

    void Update()
    {

    }
}
