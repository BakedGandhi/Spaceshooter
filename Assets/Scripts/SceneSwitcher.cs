using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public enum EScene
    {
        Game,
        Score
    }
    private static SceneSwitcher instance;
    public static SceneSwitcher Instance => instance;
    private void OnEnable()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void LoadScene(EScene _eScene)
    {
        switch (_eScene)
        {
            case EScene.Game:
                SceneManager.LoadScene("GameScene");
                break;
            case EScene.Score:
                SceneManager.LoadScene("ScoreScene");
                break;
            default:
                break;
        }
    }

}
