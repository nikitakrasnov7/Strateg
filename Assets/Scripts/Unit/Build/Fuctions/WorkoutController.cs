using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutController : MonoBehaviour
{
    GameObject build;

    private void Update()
    {
        if(UnitActionsControllerSO.Instance.RayHitObject!= null)
        {
            build = UnitActionsControllerSO.Instance.RayHitObject.gameObject;
            {
                
            }
        }
    }
}
