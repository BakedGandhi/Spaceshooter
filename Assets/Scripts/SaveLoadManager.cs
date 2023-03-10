using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public class SaveLoadManager : MonoBehaviour
{
    private static SaveLoadManager instance;
    public static SaveLoadManager Instance => instance;
    private const string FILENAME = "Highscores.score";
    private static Save save;
    public Save GetSave => save;

    private void OnEnable()
    {
        EventManager.RefreshHighScores += LoadScore; 
    }

    private void OnDisable()
    {
        EventManager.RefreshHighScores -= LoadScore;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance= this;
        DontDestroyOnLoad(this);
    }

    public void SaveScore(ScoreAndName _scoreAndName)
    {
        using (FileStream stream = new FileStream(Path.Combine(Application.dataPath, FILENAME), FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                if (save == null)
                {
                    save = new Save(_scoreAndName);
                }
                else
                {
                    save.HighScores.Add(_scoreAndName);
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
        string savePath = Path.Combine(Application.dataPath, FILENAME);
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

    public IEnumerable<ScoreAndName> OrderSavedHighScores()
    {
        return save.HighScores.OrderByDescending(x => x.Score);
    }

}
