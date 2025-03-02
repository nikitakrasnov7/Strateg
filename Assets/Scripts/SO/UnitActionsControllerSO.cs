using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class UnitActionsControllerSO : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private GameObject prefabBuild;

    [SerializeField] private bool isBuilding;
    [SerializeField] private bool isMove = true;
    

    NavMeshAgent agent;


    // Build collider

    private Image _panelCreate;
    private Image _createButton;

    public GameObject Unit {  get { return unit; } set { unit = value; } }
    public GameObject PrefabBuild {  get { return prefabBuild; } set { prefabBuild = value; } }
    public bool IsBuilding {  get { return isBuilding; } set { isBuilding = value; } }
    public bool IsMove {  get { return isMove; } set { isMove = value; } }
    

    // Build get set
    public Image PanelCreate { get { return _panelCreate; } set { _panelCreate = value; } }
    public Image CreateButton { get { return _createButton; } set { _createButton = value; } }

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
            Debug.Log(distance);
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
            
    }

    public void DestroyBuild()
    {
        
        Destroy(PrefabBuild);
        PanelCreate.gameObject.SetActive(false);
    }



}
