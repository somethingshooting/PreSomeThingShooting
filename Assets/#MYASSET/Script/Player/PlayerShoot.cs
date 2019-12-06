using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _BulletObject = null;

    [SerializeField]
    private FloatReactiveProperty _ShootInterval = new FloatReactiveProperty(1);

    [SerializeField] private string KeyShot = "space";

    private Transform _BulletParent = null;

    private float _Timer = 0;

    void Start()
    {
        _BulletParent = GameObject.FindWithTag("BulletParent").GetComponent<Transform>();

        this.UpdateAsObservable()
            .Where(_ => Vector3.Distance(Vector3.zero, transform.position) > 30)
            .Subscribe(_ => Destroy(gameObject));
    }

    private void Update()
    {
        _Timer += Time.deltaTime;
        if (_ShootInterval.Value <= _Timer && Input.GetKey(KeyShot))
        {
            Shoot();
            _Timer = 0;
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(_BulletObject, _BulletParent);
        bullet.transform.position = this.transform.position;
        bullet.transform.rotation = this.transform.rotation;
    }
}
