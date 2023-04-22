using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase<T> : State<T>
{
    EnemyController _enemyController;
    PlayerModel _target;
    EnemyModel _enemy;
    float _distance = 1;
    public float predictionTime = 1;
    public float _radius;
    public float _range = 30;
    public float _angle;
    public float _avoidanceWeight = 1;
    public float _steeringWeight = 1;
    Transform _transform;
    public LayerMask _obsMask;
    public ISteering _currentSteering;
    public ISteering _avoidance;
    ITreeNode _root;

    public EnemyChase(EnemyModel enemyModel, EnemyController enemyController, PlayerModel target, float distance, ITreeNode root,
        float Radius, float Range, float Angle, Transform Transform, LayerMask ObsMask, ISteering CurrentSteering,
        ISteering Avoidance, float AvoidanceWeight, float SteeringWeight)
    {
        _enemyController = enemyController;
        _enemy = enemyModel;
        _target = target;
        _distance = distance;
        _root = root;
        _radius = Radius;
        _range = Range;
        _angle = Angle;
        _transform = Transform;
        _obsMask = ObsMask;
        _currentSteering = CurrentSteering;
        _avoidance = Avoidance;
        _avoidanceWeight = AvoidanceWeight;
        _steeringWeight = SteeringWeight;
    }

    public override void Awake()
    {
        InitializedSteering();
    }
    void InitializedSteering()
    {
        var flee = new Flee(_transform, _target.transform);
        //var pursuit = new Pursuit(_transform, _target.transform, _target, predictionTime);
        _avoidance = flee;
    }
    public Vector3 GetDir()
    {
        Vector3 dir = _avoidance.GetDir();
        return dir;
    }
    public void SetNewSteering(ISteering newSteering)
    {
        _avoidance = newSteering;
    }
    void MoveToPlayer()
    {

        if (_enemy.IsInSight(_target.transform))
        {
            _enemy.CanSeePlayer();

        }
        else
        {
            _enemy.CantSeePlayer();
        }

        bool isLineOfSight = _enemyController.LineOfSight();
        bool isInAttackRange = _enemyController.AttackRange();
        if (isLineOfSight && !isInAttackRange)
        {
            Vector3 dir = GetDir();
            _enemy.transform.LookAt(_target.transform.position);
            var ySpeed = _enemy.GetComponent<Rigidbody>().velocity.y;
            _enemy.Move(new Vector3(dir.x * _enemy.speed, ySpeed, dir.z * _enemy.speed).normalized);
            _enemy.LookDir(new Vector3(dir.x * _enemy.speed, ySpeed, dir.z * _enemy.speed).normalized);

        }
        else if (isLineOfSight && isInAttackRange)
        {
            _root.Execute();
        }
        else
        {
            _root.Execute();
        }
    }

    public override void Execute()
    {
        MoveToPlayer();
        Debug.Log("Chasing");
    }

    public override void Sleep()
    {
        Debug.Log("Enemy ChaseState sleep");
    }
}

