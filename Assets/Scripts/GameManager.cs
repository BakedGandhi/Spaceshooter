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
    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private float spawnDelay;
    [SerializeField] private int time;
    [SerializeField] private float timeForPowerUp;
    public int Score;
    private bool isRunning;
    public int GetTime => time;
    private void OnEnable()
    {
        EventManager.StopGame += StopGameScene;
        //EventManager.StartGame += StartGame;
    }

    private void OnDisable()
    {
        EventManager.StopGame -= StopGameScene;
        //EventManager.StartGame -= StartGame;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(this);
    }

    private void StopGameScene()
    {
        isRunning = false;
        StopCoroutine(SpawnEnemyCoroutine());
        StopCoroutine(TimeTrackCoroutine());
        StopCoroutine(SpawnPowerUpCoroutine());
    }

    public void StartGame()
    {
        Score = 0;
        time = 0;
        isRunning = true;
        StartCoroutine(SpawnEnemyCoroutine());
        StartCoroutine(TimeTrackCoroutine());
        StartCoroutine(SpawnPowerUpCoroutine());
    }
    IEnumerator TimeTrackCoroutine()
    {
        while (isRunning)
        {
            Score = Score +1;
            time = time +1;
            EventManager.Instance.OnUpdateScore();
            EventManager.Instance.OnUpdateTime();
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SpawnPowerUpCoroutine()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(timeForPowerUp);
            int randomPowerUp = Random.Range(0, powerUps.Length);
            GameObject tempPowerUp = powerUps[randomPowerUp];
            Instantiate(tempPowerUp);
            timeForPowerUp = timeForPowerUp + timeForPowerUp; 
        }
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (isRunning)
        {
            int randomSpawnPoint = Random.Range(0, enemySpawnPoints.Length);
            int randomEnemy = Random.Range(0, enemies.Length);
            GameObject tempEnemy = enemies[randomEnemy];
            tempEnemy.transform.position = enemySpawnPoints[randomSpawnPoint].transform.position;
            Instantiate(tempEnemy);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

}
