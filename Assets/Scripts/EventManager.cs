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

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this.gameObject);
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
