using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    //public Menu menu;
    public GameObject player;
    public GameObject[] ball;
    public float timer;
    public Vector3[] ballpos;
    public Vector2 playerpos;
    public bool levelIsCompleted = false;
    public GameObject[] panel;
    Menu menu;

    private void Awake()
    {
        menu = GameObject.Find("UI").GetComponent<Menu>();
    }
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
        print(levelIsCompleted);
        timer -= Time.unscaledDeltaTime;
        if (timer > 0 && GameObject.FindGameObjectWithTag("Ball") == null && GameObject.FindGameObjectWithTag("Ball1") == null)
        {
            levelIsCompleted = true;
        }
        ShowImage();
    }
    public void ShowImage()
    {
        //panel[menu.imode].SetActive(false);
        if (levelIsCompleted)
        {
            panel[menu.imode].SetActive(true);
        }
    }
}

