using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBase<T> : State<T>
{
    protected EnemyModel _model;
    protected FSM<T> _fsm;

    public void InitializedState(EnemyModel model, FSM<T> fsm)
    {
        _model = model;
        _fsm = fsm;
    }
}
