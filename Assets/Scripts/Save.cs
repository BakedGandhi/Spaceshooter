using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public Dictionary<string,int> HighScores = new Dictionary<string,int>();
    public Save(Dictionary<string,int> _scores)
    {
        HighScores = _scores;
    }
}
