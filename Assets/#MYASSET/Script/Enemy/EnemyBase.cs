using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class EnemyBase : Character
{
    [SerializeField] protected int _Score = 100;

    protected Transform _BulletParent = null;
}
