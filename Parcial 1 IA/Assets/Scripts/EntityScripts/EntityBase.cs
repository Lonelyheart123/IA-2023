using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 dir)
    {
        Vector3 directionSpeed = dir * speed;
        directionSpeed.y = _rb.velocity.y;
        _rb.velocity = directionSpeed;
    }
    public void LookDir(Vector3 dir)
    {
        if (dir == Vector3.zero) return;
        dir.y = 0;
        transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * rotationSpeed);
    }
    public Vector3 GetFoward => transform.forward;
    public float GetSpeed => _rb.velocity.magnitude;

}