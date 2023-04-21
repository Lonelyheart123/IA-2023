using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool playerOnRange;
    public bool isBoxOpen;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerOnRange == true)
        {
            if(isBoxOpen == false)
            {
                isBoxOpen = true;
                Debug.Log("Caja abierta");
            }
            else
            {
                Debug.Log("Sigue abierta");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnRange = false;
        }
    }
}
