using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ScoreAndName
{
    public int Score;
    public string PlayerName;
    public ScoreAndName(string _name, int _score)
    {
        this.PlayerName = _name;
        this.Score= _score;
    }
}
