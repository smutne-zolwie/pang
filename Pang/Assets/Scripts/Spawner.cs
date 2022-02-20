using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    int ballposx;
    int ballposy;
    Vector3 position;
    float timer = 0;


    void Start()
    {
        ballposx = Random.Range(-10, 10);
        ballposy = Random.Range(0, 1);
        position = new Vector3(ballposx, ballposy, 0);
        ball.transform.position = position;
        Instantiate(player);
    }

    void Update()
    {
        timer += Time.unscaledDeltaTime;
        if (timer > 5)
        {
            Instantiate(ball, position, ball.transform.rotation);
            Destroy(gameObject);
        }
    }
}
