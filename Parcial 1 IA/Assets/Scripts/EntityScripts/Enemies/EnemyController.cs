using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyModel _enemyModel;
    FSM<EnemyStateEnum> _fsm;
    ITreeNode _root;
    ISteering _steering;
    ISteering _obsAvoidance;

    public PlayerMovement playerMove;
    public EntityBase target;
    public float multiplier;
    public float predictionTime;
    public LayerMask mask;
    public float angle;
    public float radius;
    public int maxObs;


    public float shootRange;
    private float dist;
    private float avoidanceWeight;

    private void Awake()
    {
        _enemyModel = GetComponent<EnemyModel>();
        InitializedFSM();
        InitializedTree();
        InitializedSteering();
    }
    void InitializedSteering()
    {
        var pursuit = new Pursuit(transform, target, predictionTime);
    }
    public void InitializedFSM()
    {
        var list = new List<EnemyStateBase<EnemyStateEnum>>();
        _fsm = new FSM<EnemyStateEnum>();

        var idle = new EnemyIdle<EnemyStateEnum>();
        var chase = new EnemyChase<EnemyStateEnum>(_enemyModel, this,  , dist, _root, _enemyModel.radius, _enemyModel.range,
            _enemyModel.angle, _enemyModel.transform, _enemyModel.obstacleMask, _enemyModel._currentSteering, _enemyModel._avoidance,
            _enemyModel._avoidanceWeight, _enemyModel._steeringWeight);


        var patrol = new EnemyPatrol<EnemyStateEnum>(_enemyModel, target.transform, dist, _root, _enemyModel.radius, _enemyModel.range,
            _enemyModel.angle, _enemyModel._points, _enemyModel.walkPointRange, _enemyModel._currentIndex, _enemyModel.transform,
            _enemyModel._sense, _enemyModel.obstacleMask, _enemyModel._currentSteering);
        var attack = new EnemyAttack<EnemyStateEnum>();

        list.Add(idle);
        list.Add(chase);
        list.Add(patrol);
        list.Add(attack);

        for (int i = 0; i < list.Count; i++)
        {
            list[i].InitializedState(_enemyModel, _fsm);
        }

        IState<states> patrol = new EnemyPatrol<states>(_enemyModel, target, dist, _root, _enemyModel.radius, _enemyModel.range, _enemyModel.angle, _enemyModel._points, _enemyModel.walkPointRange, _enemyModel._currentIndex, _enemyModel.transform, _enemyModel._sense, _enemyModel.obstacleMask, _enemyModel._currentSteering);
        IState<states> chase = new EnemyChase<states>(_enemyModel, this, playerMove, dist, _root, _enemyModel.radius, _enemyModel.range, _enemyModel.angle, _enemyModel.transform, _enemyModel.obstacleMask, _enemyModel._currentSteering, _enemyModel._avoidance, _enemyModel._avoidanceWeight, _enemyModel._steeringWeight);
        IState<states> attack = new EnemyAttack<states>(_enemy, this, target, dist, dir, _root);

        patrol.AddTransition(EnemyStateEnum.Chase, chase);
        chase.AddTransition(EnemyStateEnum.Patrol, patrol);

        chase.AddTransition(EnemyStateEnum.Attack, attack);
        attack.AddTransition(EnemyStateEnum.Chase, chase);

        _fsm.SetInit(idle);
    }
    void InitializedTree()
    {
        //Actions
        ITreeNode attack = new ActionNode(() => _fsm.Transitions(EnemyStateEnum.Attack));
        ITreeNode chase = new ActionNode(() => _fsm.Transitions(EnemyStateEnum.Chase));
        ITreeNode patrol = new ActionNode(() => _fsm.Transitions(EnemyStateEnum.Patrol));

        //Questions
        ITreeNode qIsEnemyClose = new QuestionNode(AttackRange, attack, chase);
        ITreeNode qLineOfSight = new QuestionNode(LineOfSight, qIsEnemyClose, patrol);

        _root = qLineOfSight;
    }
    public bool LineOfSight()
    {
        return _enemyModel.canSeePlayer;
    }
    public bool AttackRange()
    {
        bool isAttackRange = (Vector3.Distance(transform.position, target.transform.position) <= shootRange) ? true : false;
        Debug.Log("Is Shoot Range" + isAttackRange);
        return isAttackRange;
    }
    void Update()
    {
        _fsm.OnUpdate();
        _root.Execute();
        Vector3 dirAvoidance = _obsAvoidance.GetDir();
        Vector3 dir = (_steering.GetDir() + dirAvoidance * multiplier).normalized;
        _enemyModel.Move(dir);
        _enemyModel.LookDir(dir);
    }

    /*
    //DestroyEnemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy dead");
            Destroy(this.gameObject);
        }
    }*/
}
