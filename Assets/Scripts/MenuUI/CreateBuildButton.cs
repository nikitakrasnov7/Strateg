using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuildButton : MonoBehaviour
{
    public void CreateBuild()
    {
        UnitActionsControllerSO.Instance.CreateBuild();
        UIController.Instance.UiActive(true, false, false, false, false, false);
    }

    public void DestroyBuild()
    {
        UnitActionsControllerSO.Instance.DestroyBuild();
    }
}
