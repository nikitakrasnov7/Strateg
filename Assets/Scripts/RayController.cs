using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    private UnitController unitController;
    public UnitActionsControllerSO _unitActionsControllerSO;
    private Unit unit;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    Debug.Log(hit.transform.name);
                    if (hit.collider.tag == "Unit")
                    {
                        unitController = hit.collider.GetComponent<UnitController>();
                        unit = unitController.unit;

                        _unitActionsControllerSO.Unit = hit.collider.gameObject;
                        

                        UiActive(unit);
                        
                        DownInventoryManager.Instance.ActiveTrue();

                    }
                    else
                    {
                        unitController = null;
                        //DownInventoryManager.Instance.ActiveFalse();
                    }
                }


            }
        }
    }

    public void UiActive(Unit unit)
    {
        if (unit == Unit.Villager)
        {
            UIController.Instance.UiActive(true, false, false, false, true, false);
        }
        else if (unit == Unit.Healer)
        {
            UIController.Instance.UiActive(false, false, true, false, false, false);
        }
        else if (unit == Unit.Archer || unit == Unit.HeavyWarrior || unit == Unit.Knight)
        {
            UIController.Instance.UiActive(false, true, false, false, false, false);
        }
        else if (unit == Unit.Zombie)
        {
            UIController.Instance.UiActive(false, false, false, true, false, true);
        }
    }
}
