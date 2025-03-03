
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class RepairUnit : MonoBehaviour
{
    public EventSystem eventSys;
    public Image Build;
    public Image CreatePanelImage;
    public Image CreateButton;

    [Header("Text Count Resources")]
    public TextMeshProUGUI Units;
    public TextMeshProUGUI Food;
    public TextMeshProUGUI Tree;
    public TextMeshProUGUI Iron;
    public TextMeshProUGUI Rock;

    [Header("Text Cost Resources")]
    public TextMeshProUGUI UnitsCost;
    public TextMeshProUGUI FoodCost;
    public TextMeshProUGUI TreeCost;
    public TextMeshProUGUI IronCost;
    public TextMeshProUGUI RockCost;


    private void Start()
    {
        UnitActionsControllerSO.Instance.PanelCreate = CreatePanelImage;
        UnitActionsControllerSO.Instance.CreateButton = CreateButton;

        UnitActionsControllerSO.Instance.Units = Units;
        UnitActionsControllerSO.Instance.Food = Food;
        UnitActionsControllerSO.Instance.Tree = Tree;
        UnitActionsControllerSO.Instance.Iron = Iron;
        UnitActionsControllerSO.Instance.Rock = Rock;

        UnitActionsControllerSO.Instance.UnitsCost = UnitsCost;
        UnitActionsControllerSO.Instance.FoodCost = FoodCost;
        UnitActionsControllerSO.Instance.TreeCost = TreeCost;
        UnitActionsControllerSO.Instance.IronCost = IronCost;
        UnitActionsControllerSO.Instance.RockCost = RockCost;


    }


    public void ClickedRepairButton()
    {
        if (eventSys.currentSelectedGameObject.name == "Construct")
        {
            UnitActionsControllerSO.Instance.IsBuilding = true;


            Build.gameObject.SetActive(true);

        }
        else
        {
            UnitActionsControllerSO.Instance.IsBuilding = false;
            Build.gameObject.SetActive(false);
        }
    }


}
