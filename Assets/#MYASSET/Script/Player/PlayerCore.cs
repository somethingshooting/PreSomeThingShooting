using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;

public class PlayerCore : Character
{
    private Animator _PlayerAnimator = null;

    protected override void Init()
    {
        _PlayerAnimator = transform.Find("unitychan").GetComponent<Animator>();
    }

    protected override void OnDead()
    {
        _PlayerAnimator.SetBool("Dead", true);
    }
}
