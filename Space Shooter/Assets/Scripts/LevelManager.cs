using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private bool isGameOver;

    private void Update()
    {
        RestartScene();
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public void RestartScene()
    {
        if(Input.GetKeyDown(KeyCode.R) && isGameOver) 
        {
            SceneManager.LoadScene(0); //current Game Scene
        }
    }
}
