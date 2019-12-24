using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public class StreigthBullet : BulletBase
{
    [SerializeField]
    private TeamType TeamType;

    [SerializeField]
    private float MoveSpeed = 1;

    public int Damage = 1;

    [SerializeField]
    private GameObject _HitParticle = null;

    protected override void Init()
    {

    }

    protected override void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
    }

    protected override void HitOtherObject(Collider other)
    {
        Debug.Log("Hit!");
        var character = other.GetComponent<Character>();
        if (character != null && character.TeamType != this.TeamType)
        {
            if (_HitParticle != null)
            {
                var particle = Instantiate(_HitParticle, transform.position, transform.rotation);
                Destroy(particle, 1.9f);
            }
            character.ApplyDamage(Damage);
            Destroy(gameObject);
        }
    }
}
