using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : ISteering
{
    Transform _target;
    Transform _entity;
    public Seek(Transform entity, Transform target)
    {
        _entity = entity;
        SetTarget(target);
    }
    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }
    public Vector3 GetDir()
    {
        //A:Entity
        //B:Target
        //B-A
        if (_target == null) return Vector3.zero;
        Vector3 dir = _target.position - _entity.position;
        Debug.Log("Seek");
        return dir.normalized;
    }
}
