using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyStates
{
    public class EnemyPatrol<T> : State<T>
    {
        public bool _canPatrol = true;

        Transform _target;
        EnemyModel _enemy;
        float _distance = 0;
        private INode _root;
        public float _radius;
        public float _range = 30;
        public float _angle;
        public List<Transform> _points;
        public float _walkPointRange = 1;
        int _currentIndex = 0;
        Transform _transform;
        [SerializeField] int _sense;
        public LayerMask _obsMask;
        public ISteering _currentSteering;

        public EnemyPatrol(EnemyModel EnemyModel, Transform Target, float Distance, INode Root, float Radius, float Range, float Angle, List<Transform> Points, float WalkPointRange, int CurrentIndex, Transform Transform, int Sense, LayerMask ObsMask, ISteering CurrentSteering)
        {
            _target = Target;
            _enemy = EnemyModel;
            _distance = Distance;
            _root = Root;
            _radius = Radius;
            _range = Range;
            _angle = Angle;
            _points = Points;
            _walkPointRange = WalkPointRange;
            _currentIndex = CurrentIndex;
            _transform = Transform;
            _sense = Sense;
            _obsMask = ObsMask;
            _currentSteering = CurrentSteering;
        }

        public void Awake()
        {
            InitializedSteering();
        }

        void InitializedSteering()
        {
            var avoidance = new ObstacleAvoidance(_transform, _obsMask, _radius, _angle);
            _currentSteering = avoidance;//sigue y esquiva obstaculos
        }
        public void SetNewSteering(ISteering newSteering)
        {
            _currentSteering = newSteering;
        }
        public Vector3 WaypointDir()
        {
            Vector3 point = _points[_currentIndex].position;
            point.y = _transform.position.y;
            Vector3 dir = point - _transform.position;
            float distance = dir.magnitude;
            if (distance < _walkPointRange)
            {
                _currentIndex += _sense;
                if (_currentIndex >= _points.Count || _currentIndex < 0)
                {
                    _sense *= -1;
                    _currentIndex += _sense * 1;
                }
            }
            _enemy.Move(dir.normalized);
            return dir.normalized;
        }
        public override void Execute()
        {

            Debug.Log("Patrolling");
            if (_enemy.IsInSight(_target))
            {
                _enemy.CanSeePlayer();
                Debug.Log("Is in sight");
                _root.Execute();
            }
            else
            {
                WaypointDir();
                Debug.Log("HOLA");
                _enemy.CantSeePlayer();
            }

        }

        public override void Sleep()
        {
        }
    }
}
