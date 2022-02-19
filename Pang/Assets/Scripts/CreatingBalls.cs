using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingBalls : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;

    void Start()
    {
        Instantiate(player);
        Instantiate(ball);
        Destroy(gameObject);
    }
}
