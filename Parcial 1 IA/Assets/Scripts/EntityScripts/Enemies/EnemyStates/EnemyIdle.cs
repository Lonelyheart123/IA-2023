using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle<T> : EnemyStateBase<T>
{
    /*public override void Awake()
    {
        base.Awake();
        var timer = _model.GetRandomTime();
        _model.CurrentTimer = timer;
    }
    public override void Execute()
    {
        base.Execute();
        if (_model.CurrentTimer > 0)
        {
            _model.RunTimer();
        }
        else
        {
            //transition
        }
    }
    public override void Sleep()
    {
        base.Sleep();
        _model.CurrentTimer = 0;
    }*/
}
