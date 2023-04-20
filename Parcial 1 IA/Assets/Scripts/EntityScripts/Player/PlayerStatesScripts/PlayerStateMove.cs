using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMove<T> : PlayerStateBase<T>
{
    T _inputIdle;
    public PlayerStateMove(T inputIdle)
    {
        _inputIdle = inputIdle;
    }
    public override void Awake()
    {
        base.Awake();
        Debug.Log("Se está moviendo");
    }
    public override void Execute()
    {
        base.Execute();
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (h == 0 && v == 0)
        {
            _fsm.Transitions(_inputIdle);
            return;
        }

        Vector3 dir = new Vector3(h, 0, v).normalized;

        _model.Move(dir);
        _model.LookDir(dir);
    }
    public override void Sleep()
    {
        base.Sleep();
        _model.Move(Vector3.zero);
        Debug.Log("Dejó de moverse");
    }
}
