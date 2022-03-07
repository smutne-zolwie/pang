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
    Points pts;
    //public int pointsForLevel;
    public TMP_Text[] pointsLevel, timePointsT, heartPointsT, activeMapT;
    public int timePoints, heartPoints;
    Map time;
    Controller hearts;
    public GameObject[] crazyMap;


    public void Start()
    {
        pts = GameObject.Find("MapUI").GetComponent<Points>();
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
        pts.pointsForLevel = 0;
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
        pts.pointsForLevel = 0;
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

    public void LevelCompletedPanel()
    {
        for (int i = 0; i < 2; i++)
        {
            //int ii = 0;    // wiem ze bardzo nieprofesjonalne, ale musi wykonac sie tylko raz, nie mam pomyslu
            //if (ii == 0)
            //{
            //    pointsForLevel = pts.points - pointsForLevel;
            //    ii = 1;
            //}
            pointsLevel[i].text = (pts.pointsForLevel).ToString();

            if (GameObject.FindGameObjectWithTag("Map") != null)
                time = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
            timePointsT[i].text = ((int)time.timer * 50).ToString();

            if(GameObject.FindGameObjectWithTag("Player") != null)
                hearts = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
            heartPointsT[i].text = (hearts.hearts * 250).ToString();

            activeMapT[i].text = GameObject.FindGameObjectWithTag("Map").name;
        }
    }

    public void CrazyMode()
    {
        int mapIndex = Random.Range(0, 5);
        crazyMap[mapIndex].SetActive(true);
    }

    public void NextLevelCrazy()
    {
        print("next level crazy");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}