
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Image CreatePanelImage;
    public Image CreateButton;

    public GameObject PrefabUnitElement;

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

    [Header("Panel Actions")]
    public GameObject BuildCom;
    public GameObject WarriorsCom;
    public GameObject HealerCom;
    public GameObject WorkoutCom;

    public GameObject Build;
    public GameObject Workout;

    [Header("Unit and build Information Panel")]
    public GameObject FullPanel;

    public Image IconUnit;

    public Image IconTreeUnit;
    public Image IconRockUnit;
    public Image IconIronUnit;

    public TextMeshProUGUI CountTreeUnit;
    public TextMeshProUGUI CountRockUnit;
    public TextMeshProUGUI CountIronUnit;

    public TextMeshProUGUI NameUnit;
    public TextMeshProUGUI ProgressBarUnit;
    public Slider ProgressSlider;


    public GameObject ManyUnitsPanel;

    public GameObject PrefabUnitSlotForWorkout;


    List<GameObject> units = new List<GameObject>();





    private static UIController instance;
    public static UIController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindAnyObjectByType<UIController>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

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


    public void UiActive(bool buildCom, bool warriorCom, bool healerCom, bool workoutCom, bool build, bool workout)
    {
        BuildCom.SetActive(buildCom);
        WarriorsCom.SetActive(warriorCom);
        HealerCom.SetActive(healerCom);
        WorkoutCom.SetActive(workoutCom);
        Build.SetActive(build);
        Workout.SetActive(workout);

    }
    public void InformationPanel(GameObject unit)
    {

        if (unit.GetComponent<UnitController>() != null)
        {
            UnitController unCon = unit.GetComponent<UnitController>();
            IconUnit.sprite = unCon.Icon;
            NameUnit.text = unCon.unit.ToString();
            ProgressSlider.value = unCon.hp / 100f;
            ProgressBarUnit.text = $"{unCon.hp} / {unCon.hp}";

            if (unCon.unit == Unit.Villager)
            {
                IconTreeUnit.gameObject.SetActive(true);
                IconRockUnit.gameObject.SetActive(true);
                IconIronUnit.gameObject.SetActive(true);

            }
            else
            {
                IconTreeUnit.gameObject.SetActive(false);
                IconRockUnit.gameObject.SetActive(false);
                IconIronUnit.gameObject.SetActive(false);
            }

        }
    }

    public void InformationPanelClose(bool active)
    {
        FullPanel.SetActive(active);
    }
    public void ManyUnitsPanelActivation(bool active)
    {
        InformationPanelClose(false);
        ManyUnitsPanel.SetActive(active);
    }

    public void OnDisableMy()
    {
        int countChild = ManyUnitsPanel.transform.childCount;
        for (int i = 0; i < countChild; i++)
        {
            Destroy(ManyUnitsPanel.transform.GetChild(i).gameObject);
        }
        units.Clear();
    }



    public void AddedUnitElementIcon(GameObject unit)
    {

        if (!units.Contains(unit))
        {
            Debug.Log("добавление");
            GameObject slot = Instantiate(PrefabUnitElement);

            slot.GetComponentInChildren<Image>().sprite = unit.GetComponent<UnitController>().InformationUnit.IconUnit;

            slot.transform.parent = ManyUnitsPanel.transform;

            units.Add(unit);
        }
    }


    public void AddingUnitsForWorkout(List<GameObject> unitsPrefab)
    {
        int countChild = Workout.transform.childCount;
        for (int i = 0; i < countChild; i++)
        {
            Destroy(Workout.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < unitsPrefab.Count; i++)
        {
            GameObject slot = Instantiate(unitsPrefab[i]);
            slot.transform.parent = Workout.transform;

        }
    }
}
