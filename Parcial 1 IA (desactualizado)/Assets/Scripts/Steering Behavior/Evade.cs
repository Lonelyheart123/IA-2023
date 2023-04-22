using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : ISteering
{
    Transform _entity;
    Transform _target;
    IVel _targetVel;
    float _predictionTime;
    public Evade(Transform entity, Transform target, IVel targetVel, float predictionTime)
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
        //A:targetPoint
        //B:entity
        //B-A
        Vector3 dir = _entity.position - targetPoint;
        Debug.Log("Evade");
        return dir.normalized;
    }
}