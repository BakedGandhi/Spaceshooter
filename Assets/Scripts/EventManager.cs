using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;
    public static EventManager Instance => instance;

    public delegate void UpdatePlayerHealth();
    public static event UpdatePlayerHealth RefreshLifes;

    public delegate void UpdateScore();
    public static event UpdateScore RefreshScore;

    public delegate void UpdateTime();
    public static event UpdateTime RefreshTime;

    public delegate void UpdateHighscores();
    public static event UpdateHighscores RefreshHighScores;

    public delegate void StopGameScene();
    public static event StopGameScene StopGame;

    public delegate void StartGameScene();
    public static event StartGameScene StartGame;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public void OnUpdateHighScores()
    {
        if (RefreshHighScores != null)
        {
            RefreshHighScores();
        }
    }

    public void OnStopGameScene()
    {
        if (StopGame != null)
        {
            StopGame();
        }
    }

    public void OnStartGameScene()
    {
        if (StartGame != null)
        {
            StartGame();
        }
    }

    public void OnUpdateHealth()
    {
        if (RefreshLifes != null)
        {
            RefreshLifes();
        }
    }
    public void OnUpdateScore()
    {
        if (RefreshScore != null)
        {
            RefreshScore();
        }
    }
    public void OnUpdateTime()
    {
        if (RefreshTime != null)
        {
            RefreshTime();
        }
    }


}
