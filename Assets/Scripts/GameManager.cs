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
    private List<int> highScores;
    public int Time;
    public int Score;
    public bool IsRunning;

    private void OnEnable()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Awake()
    {
        try
        {
            highScores = SaveLoadManager.Instance.GetSave.HighScores;
        }
        catch (System.Exception e)
        {
            Debug.Log("Highscores could not be loaded by Gamemanger " + e);
        }
        IsRunning = true;
        Score = 0;
        Time = 0;
        StartCoroutine(SpawnEnemyCoroutine());
        StartCoroutine(TimeTrackCoroutine());
    }

    IEnumerator TimeTrackCoroutine()
    {
        while (IsRunning)
        {
            Score++;
            Time++;
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
