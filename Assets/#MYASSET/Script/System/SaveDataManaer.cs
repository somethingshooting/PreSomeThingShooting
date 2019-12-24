using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManaer : MonoBehaviour
{
    private GameManager GameManager;

    private void Start()
    {
        GameManager = GetComponent<GameManager>();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("HightScore", GameManager.HightScore);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        GameManager.HightScore = PlayerPrefs.GetInt("HightScore", 0);
    }
}
