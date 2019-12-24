using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public abstract class Character : SerializedMonoBehaviour
{
    public TeamType TeamType;

    [SerializeField]
    protected IntReactiveProperty _CurrentHealth = new IntReactiveProperty(0);
    public IReadOnlyReactiveProperty<int> CurrentHealth => _CurrentHealth;

    [SerializeField]
    protected IntReactiveProperty _MaxHealth = new IntReactiveProperty(0);
    public IReadOnlyReactiveProperty<int> MaxHealth => _MaxHealth;

    [SerializeField]
    protected FloatReactiveProperty _MoveSpeed = new FloatReactiveProperty(1);
    public IReadOnlyReactiveProperty<float> MoveSpeed => _MoveSpeed;

    protected virtual void Start()
    {
        CurrentHealth
            .SkipLatestValueOnSubscribe()
            .Where(value => value <= 0)
            .Subscribe(_ => OnDead());

        _CurrentHealth.Value = _MaxHealth.Value;

        Init();
    }

    public void ApplyDamage(int value)
    {
        if (_CurrentHealth.Value - value < 0)
        {
            _CurrentHealth.Value = 0;
        }
        else
        {
            _CurrentHealth.Value -= value;
        }
    }

    protected abstract void Init();

    protected abstract void OnDead();
}
