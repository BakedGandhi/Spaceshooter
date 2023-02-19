using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreRow scoreRow;
    private void OnEnable()
    {
        EventManager.RefreshHighScores += SetHighScores;
    }

    private void OnDisable()
    {
        EventManager.RefreshHighScores -= SetHighScores;
    }
    public void SetHighScores()
    {
        var scores = SaveLoadManager.Instance.OrderSavedHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(scoreRow, transform).GetComponent<ScoreRow>();
            row.transform.position = new Vector3(row.transform.position.x +i, row.transform.position.y, row.transform.position.z);
            row.RankText.text = (i + 1).ToString();
            row.PlayerNameText.text = scores[i].PlayerName.ToString();
            Debug.Log(scores[i].PlayerName);
            row.ScoreText.text = scores[i].Score.ToString();
        }
    }
}
