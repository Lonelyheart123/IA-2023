using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase<T> : State<T>
{
    protected PlayerModel _model;
    protected FSM<T> _fsm;
    public void InitializedState(PlayerModel model, FSM<T> fsm)
    {
        _model = model;
        _fsm = fsm;
    }
}