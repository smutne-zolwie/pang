using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject[] map;
    public int i;
    public string mode;
    public int imode;
    public GameObject randomModeCompleted;
    public GameObject campaignModeCompleted;
    //Points pts;
    //public int pointsForLevel = 0;
    //public TMP_Text pointsLevel, timePointsT, heartPointsT;
    //public int timePoints, heartPoints;
    //Map time;


    public void Start()
    {
        //pts = GameObject.Find("MapUI").GetComponent<Points>();
    }
    public void CampaignMode()
    {
        imode = 0;
        i = int.Parse(EventSystem.current.currentSelectedGameObject.name) - 1;
        map[i].SetActive(true);
    }

    public void NextLevelCampaign()
    {
        map[i].SetActive(false);
        map[i+1].SetActive(true);
        i += 1;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public void RandomMode(string rmode)
    {
        imode = 1;
        mode = rmode;
        if (rmode == "easy")
            i = Random.Range(0, 5);
        else if(rmode == "medium")
            i = Random.Range(5, 10);
        else if (rmode == "hard")
            i = Random.Range(10, 15);
        map[i].SetActive(true);
        Instantiate(map[i], map[i].transform.position, map[i].transform.rotation);
        map[i].SetActive(false);
    }

    public void NextLevelRandom()
    {
        GameObject.FindGameObjectWithTag("Map").SetActive(false);
        RandomMode(mode);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public void FinishRandomMode()
    {
        randomModeCompleted.SetActive(true);
    }

    public void HideActiveMap()
    {
        GameObject.FindGameObjectWithTag("Map").SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        
        if (GameObject.FindGameObjectsWithTag("Ball1") != null)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Ball1").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Ball1")[i]);
            }
        }
        if (GameObject.FindGameObjectsWithTag("Ball2") != null)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Ball2").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Ball2")[i]);
            }
        }
        if (GameObject.FindGameObjectsWithTag("Ball3") != null)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Ball3").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Ball3")[i]);
            }
        }
        if (GameObject.FindGameObjectsWithTag("Ball4") != null)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Ball4").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Ball4")[i]);
            }
        }
    }

    public void Update()
    {
        //pointsForLevel = pts.points - pointsForLevel;
        //pointsLevel.text = pointsForLevel.ToString();

        //time = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        //heartPointsT.text = "text";
        //heartPointsT.text = "text";
        //timePointsT.text = ((int)time.timer).ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}