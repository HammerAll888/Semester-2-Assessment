using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LevelSelect()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}