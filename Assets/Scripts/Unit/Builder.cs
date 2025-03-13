using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public InformationUnitSO InformationUnit;

    public float Endurance;
    public float Price;

    public bool isReady;

    public Building TypeBuild;

    private void Update()
    {
        if (UnitActionsControllerSO.Instance.RayHitObject != null)
        {

            if (isReady)
            {
                if (UnitActionsControllerSO.Instance.RayHitObject.gameObject.name == gameObject.name)
                {
                    Debug.Log("выбран построенный объект");
                    UIController.Instance.UiActive(false, false, false, true, false, true);
                }
                //UIController.Instance.UiActive(false, false, false, false, false, false);
            }

        }
    }


}
