using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingBalls : MonoBehaviour
{
    public GameObject ball;

    void Start()
    {
        Instantiate(ball);
        Destroy(gameObject);
    }
}
