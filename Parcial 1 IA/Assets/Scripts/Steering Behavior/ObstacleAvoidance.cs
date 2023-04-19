using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : ISteering
{
    LayerMask _obsMask;
    float _radius;
    float _angle;
    Transform _entity;
    public ObstacleAvoidance(Transform entity, LayerMask obsMask, float radius = 1, float angle = 90)
    {
        _entity = entity;
        _radius = radius;
        _obsMask = obsMask;
        _angle = angle;
    }
    public Vector3 GetDir()
    {
        Collider[] obs = Physics.OverlapSphere(_entity.position, _radius, _obsMask);
        Collider nearObs = null;
        float nearDistance = 0;
        for (int i = 0; i < obs.Length; i++)
        {
            Collider currObs = obs[i];
            Vector3 dir = currObs.transform.position - _entity.position;
            float currAngle = Vector3.Angle(_entity.forward, dir);
            if (currAngle < _angle / 2)
            {
                float currDistance = Vector3.Distance(_entity.position, currObs.transform.position);
                if (nearObs == null || nearDistance > currDistance)
                {
                    nearObs = currObs;
                    nearDistance = currDistance;
                }
            }
        }
        if (nearObs != null)
        {
            var point = nearObs.ClosestPoint(_entity.position);
            //A:Point
            //B:Entity

            //radius
            //nearDistance

            //nearDistance==Radius=0
            //0.5
            //nearDistance==0 = 1
            if (nearDistance == _radius)
            {
                nearDistance = _radius - 0.00001f;
            }
            Vector3 dir = ((_entity.position + _entity.right * 0.0000000001f) - point);
            return dir.normalized;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
