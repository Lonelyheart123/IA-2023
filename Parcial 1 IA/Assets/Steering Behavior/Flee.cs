using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : ISteering
{
    Transform _entity;
    Transform _target;
    public Flee(Transform entity, Transform target)
    {
        _entity = entity;
        SetTarget = target;
    }
    public Transform SetTarget
    {
        set
        {
            _target = value;
        }
    }
    public Vector3 GetDir()
    {   //B-A:
        //A:Target
        //B:Entity
        if (_target == null) return Vector3.zero;
        Vector3 dir = _entity.position - _target.position;
        Debug.Log("Flee");
        return dir.normalized;
    }
}
