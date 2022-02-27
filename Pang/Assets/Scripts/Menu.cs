using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject[] map;
    int i = 0;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Instantiate(map[0]);
    }

    public void NextLevel()
    {
        map[i].SetActive(false);
        map[i+1].SetActive(true);
        i += 1;
    }

    public void DestroyPlayer()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}