using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, MinMaxSlider(-10, 10, showFields: true)]
    private Vector2 _MoveableArea_X = new Vector2(-6, 6), _MoveableArea_Z = new Vector2(-1, 7.5f);

    [SerializeField]
    private float MoveSpeed = 1;

    [SerializeField, Required("使用するキーを入力してください")]
    private string KeyUp, KeyDown, KeyRight, KeyLeft;

    private PlayerCore _Core = null;
    private Animator PlayerAnimator;

    void Start()
    {
        _Core = GetComponent<PlayerCore>();

        PlayerAnimator = transform.Find("unitychan").GetComponent<Animator>();

        //値が変更されたら書き換え
        _Core.MoveSpeed.Subscribe(value => MoveSpeed = value);

        this.UpdateAsObservable()
            .Subscribe(_ => Move());
    }

    private void Move()
    {
        var movepara = 5;
        var moveDir = new Vector3();
        if (Input.GetKey(KeyUp)) {
            moveDir += Vector3.forward;
        }
        if (Input.GetKey(KeyDown)) {
            moveDir += Vector3.back;
        }
        if (Input.GetKey(KeyRight)) {
            moveDir += Vector3.right;
            movepara++;
        }
        if (Input.GetKey(KeyLeft)) {
            moveDir += Vector3.left;
            movepara--;
        }
        PlayerAnimator.SetInteger("MovePara", movepara);

        moveDir.Normalize();
        transform.Translate(moveDir * Time.deltaTime * MoveSpeed);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _MoveableArea_X.x, _MoveableArea_X.y), transform.position.y, Mathf.Clamp(transform.position.z, _MoveableArea_Z.x, _MoveableArea_Z.y));
    }
}
