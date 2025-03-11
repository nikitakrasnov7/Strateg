using UnityEngine;
using UnityEngine.AI;

public class FIghters : UnitController
{
    public float MinDistationForAttack = 15;
    public float MaxDistationForAttack;
    public float TimeDelayAttack;
    public float Damage;

    public bool isAttack = false;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isAttack)
        {
            if (UnitActionsControllerSO.Instance.RayHitObject != null)
            {
                GameObject unit = UnitActionsControllerSO.Instance.RayHitObject;
                if (unit.GetComponent<UnitController>().unit == Unit.Zombie)
                {
                    float distation = Vector3.Distance(agent.transform.position, unit.transform.position);
                    if (distation >= MinDistationForAttack)
                    {
                        agent.destination = unit.transform.position;
                    }
                    else
                    {
                        agent.isStopped = true;
                        //Debug.Log("враг рядом = стрелять");
                        gameObject.GetComponent<SwordAttack>().isAttack = true;


                        isAttack = false;
                    }
                    Debug.Log(distation);
                }
            }
        }
    }



}
