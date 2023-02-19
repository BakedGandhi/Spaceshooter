using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Manages enemy spawning, time and score
/// </summary>
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] enemySpawnPoints;
    [SerializeField] private float spawnDelay;
    [SerializeField] private int time;
    private Dictionary<string,int> highScores;
    public int Score;
    public bool IsRunning;
    public int GetTime => time;


    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
        try
        {
            highScores = SaveLoadManager.Instance.GetSave.HighScores;
        }
        catch (System.Exception e)
        {
            Debug.Log("Highscores could not be loaded by Gamemanger " + e);
        }
        IsRunning = true;
        time = 0;
        StartCoroutine(SpawnEnemyCoroutine());
        StartCoroutine(TimeTrackCoroutine());
    }

    IEnumerator TimeTrackCoroutine()
    {
        while (IsRunning)
        {
            Score = Score +1;
            time = time +1;
            EventManager.Instance.OnUpdateScore();
            EventManager.Instance.OnUpdateTime();
            yield return new WaitForSeconds(1);
        }
    }


    IEnumerator SpawnEnemyCoroutine()
    {
        while (IsRunning)
        {
            int randomSpawnPoint = Random.Range(0, enemySpawnPoints.Length);
            int randomEnemy = Random.Range(0, enemies.Length);
            GameObject tempEnemy = enemies[randomEnemy];
            tempEnemy.transform.position = enemySpawnPoints[randomSpawnPoint].transform.position;
            Instantiate(tempEnemy);
            Debug.Log(enemySpawnPoints[randomSpawnPoint]);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
