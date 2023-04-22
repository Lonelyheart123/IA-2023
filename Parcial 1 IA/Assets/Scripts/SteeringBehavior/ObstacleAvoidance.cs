using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : ISteering
{
    LayerMask _obsMask;
    float _radius;
    float _angle;
    Transform _entity;

    Collider[] _obs;
    public ObstacleAvoidance(Transform entity, LayerMask obsMask, int maxObs, float radius, float angle)
    {
        _entity = entity;
        _radius = radius;
        _obsMask = obsMask;
        _angle = angle;
        _obs = new Collider[maxObs];
    }
    public Vector3 GetDir()
    {
        //Collider[] obs = Physics.OverlapSphere(_entity.position, _radius, _obsMask);
        int countObs = Physics.OverlapSphereNonAlloc(_entity.position, _radius, _obs, _obsMask);
        Vector3 dirToAvoid = Vector3.zero;
        int detectedObs = 0;

        for (int i = 0; i < countObs; i++)
        {
            Collider currObs = _obs[i];
            Vector3 closestPoint = currObs.ClosestPointOnBounds(_entity.position);
            Vector3 diffToPoint = closestPoint - _entity.position;
            float angleToObs = Vector3.Angle(_entity.forward, diffToPoint);
            if (angleToObs > _angle / 2) continue;
            float distance = diffToPoint.magnitude;
            detectedObs++;
            dirToAvoid += -(diffToPoint).normalized * (_radius - distance);
        }
        if (detectedObs != 0)
            dirToAvoid /= detectedObs;

        return dirToAvoid.normalized;
    }
}
