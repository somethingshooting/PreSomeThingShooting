using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public abstract class BulletBase : MonoBehaviour
{ 
    [SerializeField] private TeamType TeamType;

    [SerializeField] private float MoveSpeed = 1;

    public int Damage = 1;

    protected virtual void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => Move())
            .AddTo(gameObject);

        this.OnTriggerEnterAsObservable()
            .Subscribe(_ => HitOtherObject(_))
            .AddTo(gameObject);

        this.UpdateAsObservable()
            .Where(_ => Vector3.Distance(Vector3.zero, transform.position) > 30)
            .Subscribe(_ => Destroy(gameObject))
            .AddTo(gameObject);

        Init();
    }

    protected abstract void Init();

    protected abstract void Move();

    protected abstract void HitOtherObject(Collider other);
}
