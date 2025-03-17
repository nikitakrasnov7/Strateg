
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    public InformationUnitSO InformationUnit;

    public float Endurance;
    public float Price;

    public bool isReady;

    public Building TypeBuild;

    public List<GameObject> unitsPrefworkout;

    private void Update()
    {
        if (UnitActionsControllerSO.Instance.RayHitObject != null)
        {

            if (isReady)
            {
                if (UnitActionsControllerSO.Instance.RayHitObject.gameObject.name == gameObject.name)
                {

                    Debug.Log("Click");

                    UIController.Instance.AddingUnitsForWorkout(unitsPrefworkout);

                    UIController.Instance.UiActive(false, false, false, true, false, true);

                    UnitActionsControllerSO.Instance.PrefabWorkoutBuild = UnitActionsControllerSO.Instance.RayHitObject;

                    UnitActionsControllerSO.Instance.RayHitObject = null;
                }
                //UIController.Instance.UiActive(false, false, false, false, false, false);
            }

        }
    }

   

}
