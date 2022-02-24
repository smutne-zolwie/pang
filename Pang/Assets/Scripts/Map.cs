using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject player;
    public GameObject[] ball;
    public float timer;
    public Vector3[] ballpos;
    public Vector2 playerpos;

    void Start()
    {
        for (int i = 0; i < ball.Length; i++)
        {
            Instantiate(ball[i], ballpos[i], ball[i].transform.rotation);
        }
        Instantiate(player, playerpos, player.transform.rotation);
    }

    void Update()
    {        
        timer -= Time.unscaledDeltaTime;
    }
}
