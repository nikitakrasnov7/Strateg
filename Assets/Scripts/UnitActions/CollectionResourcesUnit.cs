using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionResourcesUnit : MonoBehaviour
{
    GameObject Unit;
    Animator animator;

    void UnitToResources()
    {
        if (UnitActionsControllerSO.Instance.Unit != null)
        {
            UnitActionsControllerSO.Instance.isExtraction = true;

            Unit = UnitActionsControllerSO.Instance.Unit;
            animator = Unit.GetComponent<Animator>();
            BuildMan buildMan = Unit.GetComponent<BuildMan>();

            buildMan.isExtractionResources = true;

            UnitActionsControllerSO.Instance.IsBuilding = false;
            UIController.Instance.UiActive(true, false, false, false, false, false);

        }
    }


}
