using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostResources : MonoBehaviour
{
    public int UnitCost;
    public int FoodCost;
    public int TreeCost;
    public int IronCost;
    public int RockCost;

    private void OnEnable()
    {

            UnitActionsControllerSO.Instance.ActiveCostResources(true);
            UnitActionsControllerSO.Instance.UpdateCostResorces(UnitCost, FoodCost, TreeCost, IronCost, RockCost);
       

    }

    private void OnDestroy()
    {
        UnitActionsControllerSO.Instance.ActiveCostResources(false);
    }
}
