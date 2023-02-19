using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    private static SaveLoadManager instance;
    public static SaveLoadManager Instance => instance;
    private const string fileName = "Highscores.score";
    private static Save save;
    private string savePath = Path.Combine(Application.streamingAssetsPath, fileName);
    public Save GetSave => save;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
        if (File.Exists(savePath))
            LoadScore();
    }

    public void SaveScore(string _name,int _score)
    {
        using (FileStream stream = new FileStream(Path.Combine(Application.streamingAssetsPath, fileName), FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                if (save == null)
                {
                    Dictionary<string,int> scores = new Dictionary<string, int>();
                    scores.Add(_name,_score);
                    save = new Save(scores);
                }
                else
                {
                    save.HighScores.Add(_name,_score);
                }
                formatter.Serialize(stream, save);

            }
            catch (System.Exception e)
            {

                Debug.LogError("Saving score failed " + e);
            }
        }
    }

    public void LoadScore()
    {
        if (File.Exists(savePath))
        {
            using (FileStream stream = new FileStream(savePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    save = formatter.Deserialize(stream) as Save;
                }
                catch (System.Exception e)
                {
                    Debug.LogError("File seams to be corrupted " + e);
                }
            }
        }
        else
        {
            Debug.LogError("Save file does not exist in the current path");
        }
    }
}
