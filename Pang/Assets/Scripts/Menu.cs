using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject[] map;
    public int[] mapv;
    public bool Map;
    public bool levelIsCompleted;

    private void Start()
    {
        Map = GetComponent<bool>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void Campaign()
    {
        //void Update()
        //{
        //    for (int i = 0; i < map.Length; i++)
        //    {
        //        if (levelIsCompleted)
        //        {
        //            mapv[i] += i;
        //        }
        //        print(map[i]);
        //    }
        //}
        //Update();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //if (Input.GetKeyDown(KeyCode.Space))
        //    levelIsCompleted = true;
        //if (levelIsCompleted)
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}