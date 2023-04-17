using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : ISteering
{
    Transform _entity;
    Transform _target;
    IVel _targetVel;
    float _predictionTime;
    public Pursuit(Transform entity, Transform target, IVel targetVel, float predictionTime)
    {
        _predictionTime = predictionTime;
        _entity = entity;
        SetTarget(target, targetVel);
    }
    public void SetTarget(Transform newTarget, IVel newTargetVel)
    {
        _targetVel = newTargetVel;
        _target = newTarget;
    }
    public Vector3 GetDir()
    {
        float distance = Vector3.Distance(_entity.position, _target.position) - 0.1f;
        Vector3 targetPoint = _target.position + _targetVel.GetFoward * Mathf.Clamp(_targetVel.GetVel * _predictionTime, -distance, distance);
        //A:entity
        //B:targetPoint
        //B-A
        Vector3 dir = targetPoint - _entity.position;
        Debug.Log("Pursuit");
        return dir.normalized;
    }
}
