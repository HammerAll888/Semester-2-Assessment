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
        SceneManager.LoadSceneAsync(5);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Level1()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Level2()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void Level3()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}