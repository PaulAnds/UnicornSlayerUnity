using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string Juego;
    public GameObject mainScreen;
    public GameObject optionsScreen;

    public void StartGame()
    {
        SceneManager.LoadScene(Juego);
    }
    
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

}
