using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "RTS/Game Settings/Unit Actions", fileName = "Unit Actions")]
public class UnitActionsControllerSO : ScriptableObject
{
    [SerializeField] private GameObject unit;
    //[SerializeField] private MonoScript action;

    public GameObject Unit {  get { return unit; } set { unit = value; } }
    //public MonoScript Action {  get { return action; } set { action = value; } }

    //private static UnitActionsControllerSO instance;

    //public static UnitActionsControllerSO Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = GameObject.FindAnyObjectByType<UnitActionsControllerSO>();
    //        }
    //        return instance;
    //    }
    //}

    public void Attack(Transform point)
    {
        unit.transform.position = point.position * Time.deltaTime;
    }
    
}
