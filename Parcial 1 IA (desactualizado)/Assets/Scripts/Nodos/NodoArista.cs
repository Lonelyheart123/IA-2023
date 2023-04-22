using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoArista : MonoBehaviour
{
    public int etiqueta;
    public Nodo nodoDestino;
    public NodoArista sigArista;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, nodoDestino.transform.position);
    }
}
