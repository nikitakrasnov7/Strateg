using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUnit : MonoBehaviour
{
    GameObject unit;
    public void Attack()
    {
        if(UnitActionsControllerSO.Instance.Unit != null)
        {
            unit = UnitActionsControllerSO.Instance.Unit;

            FIghters fIghters = unit.GetComponent<FIghters>();
            fIghters.isAttack = true;


        }
    }
}
