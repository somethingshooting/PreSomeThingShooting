using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public class StageManager : SerializedMonoBehaviour
{
    /// <summary>プレイヤーの進行量 </summary>
    [SerializeField] public float TravelDistance { get; private set; } = 0;
    /// <summary> 進行速度 </summary>
    [SerializeField] public float TravelSpeed { get; private set; } = 1;

    /// <summary>  </summary>
    [SerializeField, Required]
    private StageData _StageData = null;

    void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => TravelSpeed != 0)
            .Subscribe(_ => UpdateTravel());

        foreach (var item in _StageData.EnemyList)
        {
            item.Instanced = false;
        }
    }

    private void UpdateTravel()
    {
        TravelDistance += TravelSpeed * Time.deltaTime;

        foreach (var enemy in _StageData.EnemyList)
        {
            if (enemy.InstanceTiming <= TravelDistance && enemy.Instanced == false)
            {
                enemy.Instanced = true;
                InstanceEnemy(enemy);
            }
        }
    }

    private void InstanceEnemy(StageData.EnemyData enemyData)
    {
        var enemy = Instantiate(enemyData.EnemyPrefab);
        enemy.transform.position = new Vector3(enemyData.InstancePos.x, 0, enemyData.InstancePos.y);
    }
}
