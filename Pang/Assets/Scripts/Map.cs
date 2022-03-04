using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject player;
    public GameObject[] ball;
    public float timer;
    public Vector3[] ballpos;
    public Vector2 playerpos;
    public bool levelIsCompleted = false;
    public GameObject[] panel;
    Menu menu;
    public GameObject OnDestroyPanel;

    private void Awake()
    {
        Time.timeScale = 1;
        menu = GameObject.Find("UI").GetComponent<Menu>();
    }
    void Start()
    {
        //tworzy pilki
        for (int i = 0; i < ball.Length; i++)
        {
            Instantiate(ball[i], ballpos[i], ball[i].transform.rotation);
        }
        Instantiate(player, playerpos, player.transform.rotation);
    }

    void Update()
    {
        if(levelIsCompleted == false)
            timer -= Time.unscaledDeltaTime;
        if (timer > 0 && GameObject.FindGameObjectWithTag("Ball1") == null && GameObject.FindGameObjectWithTag("Ball2") == null && GameObject.FindGameObjectWithTag("Ball3") == null && GameObject.FindGameObjectWithTag("Ball4") == null)
        {
            levelIsCompleted = true;
        }
        ShowImage();

        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            OnDestroyPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ShowImage()
    {
        if (levelIsCompleted)
        {
            panel[menu.imode].SetActive(true);
            Time.timeScale = 0;
        }
    }
}

