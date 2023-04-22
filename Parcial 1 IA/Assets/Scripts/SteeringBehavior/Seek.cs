using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : ISteering
{
    Transform _target;
    Transform _entity;
    public Seek(Transform origin, Transform target)
    {
        _entity = origin;
        _target = target;
    }
    public virtual Vector3 GetDir()
    {
        return (_target.position - _entity.position).normalized;
    }
}
