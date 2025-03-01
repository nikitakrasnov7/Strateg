using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;


public class UnitActionsControllerSO : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private GameObject prefabBuild;

    [SerializeField] private bool isBuilding;
    [SerializeField] private bool isMove = true;
    

    NavMeshAgent agent;

    public GameObject Unit {  get { return unit; } set { unit = value; } }
    public GameObject PrefabBuild {  get { return prefabBuild; } set { prefabBuild = value; } }
    public bool IsBuilding {  get { return isBuilding; } set { isBuilding = value; } }
    public bool IsMove {  get { return isMove; } set { isMove = value; } }
    

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

}
