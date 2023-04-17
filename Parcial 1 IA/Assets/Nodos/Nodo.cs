using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    [SerializeField] public Nodo NodoSiguiente;
    [SerializeField] public int info;
    [SerializeField] float radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, NodoSiguiente.transform.position);
    }
}
