using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuildButton : MonoBehaviour
{
    public ResourceCountSO ResourceCount;

    GameObject build;
    GameObject unit;

    Animator animatorBuild;
    Animator animatorUnit;
    public void CreateBuild()
    {
        build = UnitActionsControllerSO.Instance.PrefabBuild.gameObject;
        CostResources costResources = build.GetComponent<CostResources>();

        animatorBuild = build.GetComponent<Animator>();
        Debug.Log("createeee");
        unit = UnitActionsControllerSO.Instance.Unit.gameObject;
        animatorUnit = unit.GetComponent<Animator>();

        if (costResources.UnitCost <= ResourceCount.Units &&
            costResources.FoodCost <= ResourceCount.Food &&
            costResources.TreeCost <= ResourceCount.Tree &&
            costResources.IronCost <= ResourceCount.Iron &&
            costResources.RockCost <= ResourceCount.Rock )
        {
            Debug.Log("modmdsmdmdmddm");
            UnitActionsControllerSO.Instance.CreateBuild();
            UnitActionsControllerSO.Instance.ActiveCostResources(false);

            animatorUnit.SetBool("Going", true);

            animatorBuild.SetTrigger("StartBuilding");

            UIController.Instance.UiActive(true, false, false, false, false, false);

            UnitActionsControllerSO.Instance.UpdateCountResorces(costResources.UnitCost, costResources.FoodCost, costResources.TreeCost, costResources.IronCost, costResources.RockCost);

        }


    }

    public void DestroyBuild()
    {
        UnitActionsControllerSO.Instance.DestroyBuild();
    }
}
