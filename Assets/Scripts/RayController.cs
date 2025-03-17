using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    //private UnitController unitController;
    private Unit unit;
    private float timer;

    bool isStartTimer;
    bool isChosen = false;

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

                    if (hit.collider.tag == "Unit")
                    {
                        isStartTimer = true;

                        GameObject unitPref = hit.collider.gameObject;
                        unit = unitPref.GetComponent<UnitController>().unit;

                        UnitActionsControllerSO.Instance.Unit = hit.collider.gameObject;

                        //UnitActionsControllerSO.Instance.RayHitObject = hit.collider.gameObject;

                        if (isChosen)
                        {
                            
                            var icon = unitPref.GetComponent<UnitController>().InformationUnit.IconUnit;
                            UIController.Instance.AddedUnitElementIcon(unitPref);
                            UIController.Instance.InformationPanelClose(false);



                        }
                        else
                        {
                            UIController.Instance.ManyUnitsPanelActivation(false);
                            UIController.Instance.InformationPanelClose(true);
                            UIController.Instance.InformationPanel(unitPref);
                        }



                        UiActive(unit);

                        DownInventoryManager.Instance.ActiveTrue();

                    }
                    else
                    {
                        UIController.Instance.InformationPanelClose(false);
                        UIController.Instance.OnDisableMy();
                        UIController.Instance.ManyUnitsPanelActivation(false);



                        isChosen = false;

                        isStartTimer = false;

                    }

                    UnitActionsControllerSO.Instance.RayHitObject = hit.collider.gameObject;
                }
            }
            if (touch.phase == TouchPhase.Stationary)
            {
                if (isStartTimer)
                {
                    timer += 0.01f;

                    if (timer > 3)
                    {
                        isChosen = true;

                        UIController.Instance.ManyUnitsPanelActivation(true);


                    }
                    //Timer();

                }

            }
            if (touch.phase == TouchPhase.Ended)
            {
                timer = 0f;
            }


        }
    }


    public void UiActive(Unit unit)
    {
        if (unit == Unit.Villager)
        {
            UIController.Instance.UiActive(true, false, false, false, false, false);
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
