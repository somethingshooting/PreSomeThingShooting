using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "StageData_",menuName = "Stage/StageData", order = 1)]
public class StageData : SerializedScriptableObject
{

    [SerializeField]
    public List<EnemyData> EnemyList = new List<EnemyData>();

    public class EnemyData
    {
        [SerializeField, Required]
        public GameObject EnemyPrefab = null;

        [SerializeField]
        public float InstanceTiming = 0;

        [SerializeField]
        public Vector2 InstancePos = new Vector2();

        public bool Instanced = false;
    }
}
