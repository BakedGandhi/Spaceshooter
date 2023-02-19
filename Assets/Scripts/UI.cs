using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text heathText;

    private void OnEnable()
    {
        EventManager.RefreshLifes += UpdateLifesUI;
        EventManager.RefreshScore += UpdateScoreUI;
        EventManager.RefreshTime += UpdateTimeUI;
        heathText.text = playerController.GetPlayerHealth.ToString();
    }

    private void OnDisable()
    {
        EventManager.RefreshLifes -= UpdateLifesUI;
        EventManager.RefreshScore -= UpdateScoreUI;
        EventManager.RefreshTime -= UpdateTimeUI;
    }

    private void UpdateLifesUI()
    {
        heathText.text = playerController.GetPlayerHealth.ToString();
    }
    private void UpdateScoreUI()
    {
        scoreText.text = GameManager.Instance.Score.ToString();
    }
    private void UpdateTimeUI()
    {
        timeText.text = GameManager.Instance.GetTime.ToString();
    }

}
