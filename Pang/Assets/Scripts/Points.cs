using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    public int points = 0;
    public GameObject[] ball;
    public Collider2D[] bcollider;
    Map time;
    Controller heart;
    public TMP_Text[] Tpoints;
    public TMP_Text Timer;

    public void AddHeartAndTimePoints()
    {
        //dla buttona
        heart = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
        points += heart.hearts * 250;
    
        time = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        points += ((int)time.timer) * 50;
    }

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Map") != null) //tylko po to, zeby nie wywalalo mi bledu w konsoli, czytaj, jakby nie bylo w ifie
        {
            //dodawanie punktow
            time = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
            for (int i = 0; i < Tpoints.Length; i++)
            {
                Tpoints[i].text = points.ToString();
            }
            Timer.text = ((int)time.timer).ToString();
        }
    }
}