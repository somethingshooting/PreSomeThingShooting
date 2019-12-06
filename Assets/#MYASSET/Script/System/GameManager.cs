using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public class GameManager : SerializedMonoBehaviour
{
    private static bool _Instance = true;

    [SerializeField]
    public int Score { get; private set; } = 0;

    void Start()
    {
        if (_Instance)
        {
            _Instance = false;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        Score += value;
    }
}
