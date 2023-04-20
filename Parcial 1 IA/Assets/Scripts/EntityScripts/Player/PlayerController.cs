using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerModel _model;
    FSM<PlayerStatesEnum> _fsm;
    List<PlayerStateBase<PlayerStatesEnum>> _states;
    void InitializedFSM()
    {
        _fsm = new FSM<PlayerStatesEnum>();
        _states = new List<PlayerStateBase<PlayerStatesEnum>>();
        var idle = new PlayerStateIdle<PlayerStatesEnum>(PlayerStatesEnum.Running);
        var move = new PlayerStateMove<PlayerStatesEnum>(PlayerStatesEnum.Idle);

        _states.Add(idle);
        _states.Add(move);

        idle.AddTransition(PlayerStatesEnum.Running, move);

        move.AddTransition(PlayerStatesEnum.Idle, idle);


        for (int i = 0; i < _states.Count; i++)
        {
            _states[i].InitializedState(_model, _fsm);
        }
        _states = null;

        _fsm.SetInit(idle);
    }
    private void Awake()
    {
        _model = GetComponent<PlayerModel>();
        InitializedFSM();
    }
    private void Update()
    {
        _fsm.OnUpdate();
    }
}
