using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;

public class ArmUnit : MonoBehaviour

{
    public UnitActionsControllerSO _unitActionsControllerSO;
    public bool Arm  = false;

    void Start()
    {
        _unitActionsControllerSO = UnitActionsControllerSO.Instance;
    }

    public void ArmToggle()
    {
        Arm = !Arm;
    }


    // Update is called once per frame
    void Update()
    {
        if (Arm)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name == "Terrain")
                    {
                        if (_unitActionsControllerSO.Unit != null)
                        {
                            GameObject vat = _unitActionsControllerSO.Unit;

                            NavMeshAgent agent = vat.GetComponent<NavMeshAgent>();
                            if (agent != null)
                            {
                                agent.destination = hit.point;
                                _unitActionsControllerSO.ArmController(agent);
                                //  float distance = Vector3.Distance(agent.transform.position, hit.point);

                            }
                        }

                        //vat.transform.position = hit.point * 10f * Time.fixedDeltaTime;



                    }

                }
            }
        }
    }
}
