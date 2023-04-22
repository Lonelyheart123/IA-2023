using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{
    IState<T> _current;
    public FSM() { }
    public FSM(IState<T> init)
    {
        SetInit(init);
    }
    public void SetInit(IState<T> initState)
    {
        _current = initState;
        _current.Awake();
    }
    public void OnUpdate()
    {
        if (_current != null)
        {
            _current.Execute();
        }
    }
    public void Transitions(T input)
    {
        IState<T> newState = _current.GetTransition(input);
        if (newState != null)
        {
            _current.Sleep();
            _current = newState;
            _current.Awake();
        }
    }
}