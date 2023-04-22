using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDucking<T> : PlayerStateBase<T>
{
    public override void Awake()
    {
        base.Awake();
        _model.Dead();
    }
}
