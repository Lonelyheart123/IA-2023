using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : EntityBase //MonoBehaviour, IVel
{
    //public Action OnCollision = delegate { };
    /*public float GetVel => _rb.velocity.magnitude;
    public Vector3 GetFoward => transform.forward;

    Transform _target;
    Transform _entity;
    Transform _transform;
    Rigidbody _rb;
    Seek seek;
    //public Bullet _enemyBullet;
    public EnemyController enemyController;*/

    public float range = 30;
    public float angle = 90;
    /*public int speed;

    public float radius;
    public List<Transform> _points;
    public float walkPointRange = 1;
    public int _sense;
    public int _currentIndex = 0;
    public float _avoidanceWeight = 1;
    public float _steeringWeight = 1;
    public float _predictionTime = 2;*/

    public LayerMask obstacleMask;
    /*internal Vector3 position;
    public ISteering _currentSteering;
    public ISteering _avoidance;

    //int _lastFrameLOS;
    //bool _cacheLOS;*/
    public bool canSeePlayer;
    /*private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    //MOVE
    public void Move(Vector3 dir)
    {
        dir.y = 0;
        _rb.velocity = dir * speed;
    }
    //LOOK-DIR
    public void LookDir(Vector3 dir)
    {
        dir.y = 0;
        transform.forward = Vector3.Lerp(transform.forward, dir, 0.2f);
    }*/

    //IN-SIGHT
    public bool IsInSight(Transform target)
    {
        Vector3 diff = (transform.position - target.position);
        float distance = diff.magnitude;
        if (distance > range) return false;

        float angleToTarget = Vector3.Angle(transform.position, diff);
        if (angleToTarget > angle / 2) return false;

        Vector3 dirToTarget = diff.normalized;
        if (Physics.Raycast(transform.position, dirToTarget, distance, obstacleMask)) return false;

        return true;
    }
    public void CanSeePlayer()
    {
        canSeePlayer = true;
    }
    public void CantSeePlayer()
    {
        canSeePlayer = false;
    }

    /*//ATTACK
    public void Attack(Vector3 dir)
    {
        Bullet bullet = Instantiate<Bullet>(_enemyBullet);
        bullet.transform.position = transform.position;
        bullet.SetDir = dir;
    }*/

    /*//ON-COLLISION-ENTER
    private void OnCollisionEnter(Collision collision)
    {
        var entity = collision.gameObject.GetComponent<IEntity>();
        if (entity != null)
        {
            OnCollision();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy dead");
            Destroy(this.gameObject);
        }
    }*/

    //GIZMOS
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * range);
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, angle / 2, 0) * transform.forward * range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -angle / 2, 0) * transform.forward * range);
    }
}
