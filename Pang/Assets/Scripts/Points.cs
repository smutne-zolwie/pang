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
    public TMP_Text Tpoints;
    public TMP_Text Timer;

    public void AddHeartAndTimePoints()
    {
        heart = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>(); //problem gdy gracz nie zyje
        points += heart.hearts * 250;
    
        time = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        points += ((int)time.timer) * 50;
    }

    private void Update()
    {
        time = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        Tpoints.text = points.ToString();
        Timer.text = ((int)time.timer).ToString();
    }
}