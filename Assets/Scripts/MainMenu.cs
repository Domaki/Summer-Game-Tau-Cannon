using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("LoadIn");
    }

    public void Level()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Settings");
    }
}
