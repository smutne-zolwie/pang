using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public GameObject[] map;
    int i = 0;
    //string levelstr; 22
    public Button[] levels;
    public int buttonvalue;

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void GetValue(string arg)
    {
        //levelstr = arg; 22
        //dynamic string
    }
    
    public void CampaignMode()
    {
        buttonvalue = int.Parse(EventSystem.current.currentSelectedGameObject.name) - 1; //-1 bo tablice numerujemy od 0 :))
        map[buttonvalue].SetActive(true);
    }

    public void NextLevel()
    {
        map[i].SetActive(false);
        map[i+1].SetActive(true);
        i += 1;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public void RandomMode()
    {
        SceneManager.LoadScene(2);
    }

    public void EasyRandom()
    {
        //SceneManager.LoadScene(2);
        //i = Random.Range(0, 5);
        //print(i);
        //map[i].SetActive(true);
    }

    private void Update()
    {
        
    }
}