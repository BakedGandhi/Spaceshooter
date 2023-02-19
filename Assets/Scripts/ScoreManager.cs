using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    public void CreateHighScore()
    {
        ScoreAndName scoreAndName = new ScoreAndName(nameText.ToString(), GameManager.Instance.Score);
        SaveLoadManager.Instance.SaveScore(scoreAndName);
        EventManager.Instance.OnUpdateHighScores();
    }
}
