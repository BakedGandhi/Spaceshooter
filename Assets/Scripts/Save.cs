using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public List<int> HighScores = new List<int>();
    public Save(List<int> _scores)
    {
        HighScores = _scores;
    }
}
