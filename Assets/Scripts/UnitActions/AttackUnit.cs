using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUnit : MonoBehaviour
{
    public void Attack(GameObject unit, Vector3 position)
    {
        unit.transform.position = position;
    }
}
