using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionResourcesUnit : MonoBehaviour
{
    GameObject Unit;

    void UnitToResources()
    {
        if (UnitActionsControllerSO.Instance.Unit != null)
        {
            Unit = UnitActionsControllerSO.Instance.Unit;

            //UnitActionsControllerSO.Instance.isExtraction = true;

            BuildMan buildMan = Unit.GetComponent<BuildMan>();

            buildMan.isExtractionResources = true;

            UnitActionsControllerSO.Instance.IsBuilding = false;
            UIController.Instance.UiActive(true, false, false, false, false, false);

        }
    }


}
