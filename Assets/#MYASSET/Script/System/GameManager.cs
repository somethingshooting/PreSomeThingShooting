using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public class GameManager : SerializedMonoBehaviour
{
    private static bool _Instance = true;

    [SerializeField]
    public int Score { get; private set; } = 0;
    [SerializeField]
    public int HightScore = 0;

    private SaveDataManaer SaveDataManaer;

    void Start()
    {
        SaveDataManaer = GetComponent<SaveDataManaer>();
        if (_Instance)
        {
            _Instance = false;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SaveDataManaer.LoadData();
    }

    public void AddScore(int value)
    {
        Score += value;
        if (HightScore < Score)
        {
            HightScore = Score;
        }
    }

    public void ChangeScene(SceneType sceneType)
    {
        var sceneName = "";
        switch (sceneType)
        {
            case SceneType.Title:
                sceneName = "TitleScene";
                SaveDataManaer.LoadData();
                break;
            case SceneType.Battle:
                sceneName = "BattleScene";
                break;
            case SceneType.Result:
                sceneName = "ResultScene";
                SaveDataManaer.SaveData();
                break;
            case SceneType.CharacterSelect:
                sceneName = "CharacterSelectScene";
                break;
            default:
                break;
        }
        SceneManager.LoadSceneAsync(sceneName);
    }
}

public enum SceneType
{
    Title,
    Battle,
    Result,
    CharacterSelect,
}