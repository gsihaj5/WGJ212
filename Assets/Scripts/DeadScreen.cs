using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreen : MonoBehaviour
{
    private GameObject _scoreManager;

    private void Start()
    {
        _scoreManager = GameObject.Find("ScoreManager");
    }

    public void restart()
    {
        SceneManager.LoadScene("Game");
        _scoreManager.GetComponent<ScoreManager>().enemyKilled = 0;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        _scoreManager.GetComponent<ScoreManager>().enemyKilled = 0;
    }
}