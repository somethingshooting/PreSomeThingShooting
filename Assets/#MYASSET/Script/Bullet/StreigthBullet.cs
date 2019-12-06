using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public class StreigthBullet : MonoBehaviour
{
    [SerializeField]
    private TeamType TeamType;

    [SerializeField]
    private float MoveSpeed = 1;

    public int Damage = 1;

    void Start()
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
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
    }

    private void HitOtherObject(Collider other)
    {
        Debug.Log("Hit!");
        var character = other.GetComponent<Character>();
        if (character != null && character.TeamType != this.TeamType)
        {
            character.ApplyDamage(Damage);
        }
    }
}
