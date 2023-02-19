using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public enum EScene
    {
        Game,
        Score
    }

    private static SceneSwitcher instance;
    public static SceneSwitcher Instance => instance;
    private void OnEnable()
    {
        EventManager.StartGame += LoadGameScene;
        EventManager.StopGame += LoadScoreScene;
    }

    private void OnDisable()
    {
        EventManager.StartGame -= LoadGameScene;
        EventManager.StopGame -= LoadScoreScene;
    }
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void LoadGameScene()
    {
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.Log("I am already in Game Scene");
        }
    }

    private void LoadScoreScene()
    {
        if (SceneManager.GetActiveScene().name != "ScoreScene")
        {
            SceneManager.LoadScene("ScoreScene");
        }

    }
}
