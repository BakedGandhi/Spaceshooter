using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public List<ScoreAndName> HighScores = new List<ScoreAndName>();
    public Save(ScoreAndName _scoreAndName)
    {
        HighScores.Add(_scoreAndName);
    }
}
