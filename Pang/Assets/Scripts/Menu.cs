using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public GameObject[] map;
    public int i;
    public int buttonvalue;

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    
    public void CampaignMode()
    {
        buttonvalue = int.Parse(EventSystem.current.currentSelectedGameObject.name) - 1;
        map[buttonvalue].SetActive(true);
    }

    public void NextLevelCampaign()
    {
        print(GameObject.FindGameObjectWithTag("Map").name);
        string f = GameObject.FindGameObjectWithTag("Map").name;
        i = int.Parse(f.ToString())-1;
        map[i].SetActive(false);
        map[i+1].SetActive(true);
        i += 1;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public void EasyRandomMode()
    {
        i = Random.Range(0, 5);
        map[i].SetActive(true);
    }

    public void MediumRandomMode()
    {
        i = Random.Range(5, 10);
        map[i].SetActive(true);
    }

    public void HardRandomMode()
    {
        i = Random.Range(10, 15);
        map[i].SetActive(true);
    }


    public void NextEasyLevel()
    {
        GameObject.FindGameObjectWithTag("Map").SetActive(false);
        EasyRandomMode();
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }


    public void NextMediumLevel()
    {
        GameObject.FindGameObjectWithTag("Map").SetActive(false);
        MediumRandomMode();
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }


    public void NextHardLevel()
    {
        GameObject.FindGameObjectWithTag("Map").SetActive(false);
        HardRandomMode();
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}