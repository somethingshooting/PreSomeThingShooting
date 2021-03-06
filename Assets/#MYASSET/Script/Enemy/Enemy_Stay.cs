﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public class Enemy_Stay : EnemyBase
{
    [SerializeField]
    private float _ShotInterval = 1;

    [SerializeField, Required]
    private GameObject _BulletObject = null;

    protected override void Init()
    {
        _BulletParent = GameObject.FindWithTag("BulletParent").GetComponent<Transform>();

        Observable.Interval(TimeSpan.FromSeconds(_ShotInterval))
            .Subscribe(_ => Shoot())
            .AddTo(gameObject);
    }

    private void Shoot()
    {
        var bullet = Instantiate(_BulletObject, _BulletParent);
        bullet.transform.position = transform.position;
        var player = GameObject.FindWithTag("Player");
        bullet.transform.LookAt(new Vector3(player.transform.position.x, bullet.transform.position.y, player.transform.position.z));
    }

    protected override void OnDead()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().AddScore(_Score);
        Destroy(gameObject);
    }
}
