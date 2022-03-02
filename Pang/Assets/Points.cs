using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int points = 0;
    public GameObject[] ball;
    public Collider2D[] bcollider;
    Map time;
    Controller heart;

    public void AddHeartAndTimePoints()
    {
        //dziala
        heart = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
        points += heart.hearts * 250;
    
        time = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        points += ((int)time.timer) * 50;
    }
}