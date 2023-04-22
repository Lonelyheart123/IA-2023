using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : ISteering
{
    Transform _entity;
    EntityBase _target;
    float _predictionTime;
    public Pursuit(Transform entity, EntityBase target, float predictionTime)
    {
        _entity = entity;
        _target = target;
        _predictionTime = predictionTime;
    }
    public virtual Vector3 GetDir()
    {
        float distance = Vector3.Distance(_entity.position, _target.transform.position) - 0.1f;
        Vector3 targetPoint = _target.transform.position + _target.GetFoward * Mathf.Clamp(_target.GetSpeed * _predictionTime, 0, distance);
        Debug.Log("Pursuit");
        return (targetPoint - _entity.position).normalized;
    }
}
