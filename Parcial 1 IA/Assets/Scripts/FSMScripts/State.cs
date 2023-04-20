using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State<T> : IState<T>
{
    Dictionary<T, IState<T>> _transitions = new Dictionary<T, IState<T>>();
    FSM<T> _fsm;

    public FSM<T> StateMachine
    {
        get
        {
            return _fsm;
        }

        set
        {
            _fsm = value;
        }
    }

    public virtual void Awake()
    {

    }

    public virtual void Execute()
    {

    }


    public virtual void Sleep()
    {

    }

    public void AddTransition(T input, IState<T> state)
    {
        if (!_transitions.ContainsKey(input))
            _transitions[input] = state;
    }

    public void RemoveTransition(T input)
    {
        if (_transitions.ContainsKey(input))
            _transitions.Remove(input);
    }

    public void RemoveTransition(IState<T> state)
    {
        foreach (var item in _transitions)
        {
            var currState = item.Value;
            if (currState == state)
            {
                var input = item.Key;
                _transitions.Remove(input);
                break;
            }
        }
    }

    public IState<T> GetTransition(T input)
    {
        if (_transitions.ContainsKey(input))
        {
            return _transitions[input];
        }
        return null;
    }
}