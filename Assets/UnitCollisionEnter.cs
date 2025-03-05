using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitCollisionEnter : MonoBehaviour
{
    public bool isGoing = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Build")
        {
            isGoing = false;
        }
    }
}
