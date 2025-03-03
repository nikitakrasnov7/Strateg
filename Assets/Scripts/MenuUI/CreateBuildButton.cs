using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuildButton : MonoBehaviour
{
    public ResourceCountSO ResourceCount;
    GameObject build;
    public void CreateBuild()
    {
        build = UnitActionsControllerSO.Instance.PrefabBuild.gameObject;
        CostResources costResources = build.GetComponent<CostResources>();

        if (costResources.UnitCost <= ResourceCount.Units &&
            costResources.FoodCost <= ResourceCount.Food &&
            costResources.TreeCost <= ResourceCount.Tree &&
            costResources.IronCost <= ResourceCount.Iron &&
            costResources.RockCost <= ResourceCount.Rock )
        {
            UnitActionsControllerSO.Instance.CreateBuild();
            UnitActionsControllerSO.Instance.ActiveCostResources(false);

            UIController.Instance.UiActive(true, false, false, false, false, false);

            UnitActionsControllerSO.Instance.UpdateCountResorces(costResources.UnitCost, costResources.FoodCost, costResources.TreeCost, costResources.IronCost, costResources.RockCost);

        }


    }

    public void DestroyBuild()
    {
        UnitActionsControllerSO.Instance.DestroyBuild();
    }
}
