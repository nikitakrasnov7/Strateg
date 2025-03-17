using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class UnitActionsControllerSO : MonoBehaviour
{
    //================================================
    [SerializeField] private GameObject unit;
    [SerializeField] private GameObject prefabBuild;

    [SerializeField] private bool isMove = true;

    public GameObject Unit { get { return unit; } set { unit = value; } }
    public GameObject PrefabBuild { get { return prefabBuild; } set { prefabBuild = value; } }
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    //===================================================


    NavMeshAgent agent;


    public ListBuildForResources listBuild;
    // Build collider
    //=========================================
    private Image _panelCreate;
    private Image _createButton;
    [SerializeField] private bool isBuilding;
    private bool isUnitMove = false;
    private bool isGoing;

    // Build get set
    public Image PanelCreate { get { return _panelCreate; } set { _panelCreate = value; } }
    public Image CreateButton { get { return _createButton; } set { _createButton = value; } }
    public bool IsBuilding { get { return isBuilding; } set { isBuilding = value; } }

    public bool IsUnitMove { get { return isUnitMove; } set { isUnitMove = value; } }

    public bool IsGoing { get { return isGoing; } set { isGoing = value; } }
    //=========================================

    // Resources count
    //=========================================
    private TextMeshProUGUI _units;
    private TextMeshProUGUI _food;
    private TextMeshProUGUI _tree;
    private TextMeshProUGUI _iron;
    private TextMeshProUGUI _rock;

    public TextMeshProUGUI Units { get { return _units; } set { _units = value; } }
    public TextMeshProUGUI Food { get { return _food; } set { _food = value; } }
    public TextMeshProUGUI Tree { get { return _tree; } set { _tree = value; } }
    public TextMeshProUGUI Iron { get { return _iron; } set { _iron = value; } }
    public TextMeshProUGUI Rock { get { return _rock; } set { _rock = value; } }
    //=========================================

    public ResourceCountSO ResourceCount;
    // Resources Cost
    //=========================================
    private TextMeshProUGUI _unitsCost;
    private TextMeshProUGUI _foodCost;
    private TextMeshProUGUI _treeCost;
    private TextMeshProUGUI _ironCost;
    private TextMeshProUGUI _rockCost;

    public TextMeshProUGUI UnitsCost { get { return _unitsCost; } set { _unitsCost = value; } }
    public TextMeshProUGUI FoodCost { get { return _foodCost; } set { _foodCost = value; } }
    public TextMeshProUGUI TreeCost { get { return _treeCost; } set { _treeCost = value; } }
    public TextMeshProUGUI IronCost { get { return _ironCost; } set { _ironCost = value; } }
    public TextMeshProUGUI RockCost { get { return _rockCost; } set { _rockCost = value; } }
    //=========================================


    public Animator AnimUnit;

    // ====================================
    public bool isExtraction;



    GameObject rayHitObject;

    public GameObject RayHitObject { get { return rayHitObject; } set { rayHitObject = value; } }

    public GameObject PrefabWorkoutBuild;


    private static UnitActionsControllerSO instance;

    public static UnitActionsControllerSO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindAnyObjectByType<UnitActionsControllerSO>();
            }
            return instance;
        }
    }

    private void Start()
    {
        _units.text = ResourceCount.Units.ToString();
        _food.text = ResourceCount.Food.ToString();
        _tree.text = ResourceCount.Tree.ToString();
        _iron.text = ResourceCount.Iron.ToString();
        _rock.text = ResourceCount.Rock.ToString();


    }

    private void Update()
    {


        if (agent != null)
        {
            float distance = Vector3.Distance(agent.transform.position, agent.destination);
            if (distance < 0.5f)
            {
                unit = null;
                agent = null;
            }

        }
    }

    public void ArmController(NavMeshAgent agent)
    {
        this.agent = agent;
    }

    public void CreatePanelController(bool toogle)
    {
        PanelCreate.gameObject.SetActive(toogle);
    }

    public void CreateButtonController(bool toggle)
    {
        CreateButton.gameObject.SetActive(toggle);
    }

    public void CreateBuild()
    {
        Canvas canva = PrefabBuild.GetComponentInChildren<Canvas>();

        IsBuilding = false;
        PanelCreate.gameObject.SetActive(false);
        Destroy(canva.gameObject);

        AddBuildPosition(PrefabBuild);

    }

    public void DestroyBuild()
    {

        Destroy(PrefabBuild);
        PanelCreate.gameObject.SetActive(false);
    }


    public void UpdateCostResorces(int costUnit, int costFood, int costTree, int costIron, int costRock)
    {
        UnitsCost.text = "-" + costUnit.ToString();
        FoodCost.text = "-" + costFood.ToString();
        TreeCost.text = "-" + costTree.ToString();
        IronCost.text = "-" + costIron.ToString();
        RockCost.text = "-" + costRock.ToString();
    }

    public bool IfNull()
    {
        if (UnitsCost.text != null &&
        FoodCost.text != null &&
        TreeCost.text != null &&
        IronCost.text != null &&
        RockCost.text != null)
        {
            return true;
        }
        return false;
    }
    public void UpdateCountResorces(int countUnit, int countFood, int countTree, int countIron, int countRock)
    {
        ResourceCount.Units -= countUnit;
        ResourceCount.Food -= countFood;
        ResourceCount.Tree -= countTree;
        ResourceCount.Iron -= countIron;
        ResourceCount.Rock -= countRock;

        Units.text = (ResourceCount.Units).ToString();
        Food.text = (ResourceCount.Food).ToString();
        Tree.text = (ResourceCount.Tree).ToString();
        Iron.text = (ResourceCount.Iron).ToString();
        Rock.text = (ResourceCount.Rock).ToString();
    }

    public void ActiveCostResources(bool toggle)
    {
        if (UnitsCost != null &&
            FoodCost != null &&
            TreeCost != null &&
            IronCost != null &&
            RockCost != null)
        {

            UnitsCost.gameObject.SetActive(toggle);
            FoodCost.gameObject.SetActive(toggle);
            TreeCost.gameObject.SetActive(toggle);
            IronCost.gameObject.SetActive(toggle);
            RockCost.gameObject.SetActive(toggle);
        }

    }

    public void Building(GameObject PrefabForGame)
    {

        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray ray = Camera.main.ScreenPointToRay(center);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (IsBuilding)
            {

                if (hit.collider.name == "Terrain")
                {
                    var test = hit.point;

                    var build = Instantiate(PrefabForGame);
                    PrefabBuild = build.gameObject;

                    build.AddComponent<ColliderFunctions>();

                    build.transform.position = test;


                    if (PanelCreate != null)
                    {
                        CreatePanelController(true);
                    }
                }
            }
        }

    }



    public void StartAnimator(GameObject unit, string triggerName, GameObject build)
    {
        Animator BuildAnim = build.GetComponent<Animator>();
        BuildAnim.SetTrigger(triggerName);

        if (BuildAnim)
        {
            unit.GetComponent<FinishBuilding>().buildingAnimator = BuildAnim;
        }


    }

    public void ActivationUnit(bool active)
    {
        ActivationUnits activation;
        activation = unit.GetComponent<ActivationUnits>();
    }

    public void AddBuildPosition(GameObject build)
    {
        listBuild.BuildPosition.Add(build);
    }

    public void InstantiateNewUnitsWorkout(GameObject prefabUnits, GameObject positionForParentBuild, float x, float z)
    {
        GameObject unit = Instantiate(prefabUnits);


        unit.transform.position = positionForParentBuild.transform.position;
        unit.transform.parent = positionForParentBuild.transform;

        if (unit.transform.position == positionForParentBuild.transform.position)
        {
            while (true)
            {
                float posX = Random.Range(-10f, 10f);
                float posZ = Random.Range(-10f, 10f);
                if (!((posX >= -2 && posX <= 2) && (posZ >= -2 && posZ <= 2)))
                {
                    unit.transform.position = new Vector3(positionForParentBuild.transform.position.x + posX,
                        0,
                        positionForParentBuild.transform.position.z + posZ
                        );
                    break;
                }
            }
        }


    }

   
}
