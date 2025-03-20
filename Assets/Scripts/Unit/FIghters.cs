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

    private bool isZombi;
    GameObject zombi;

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
                if (unit.tag == "ZombiGo")
                {
                    float distation = Vector3.Distance(agent.transform.position, unit.transform.position);
                    if (distation >= MinDistationForAttack)
                    {
                        agent.destination = unit.transform.position;

                    }
                    else
                    {

                        //Debug.Log("враг рядом = стрелять");
                        gameObject.GetComponent<SwordAttack>().isAttack = true;

                        agent.isStopped = true;

                        isAttack = false;
                    }
                }
            }
        }

        if (isZombi)
        {
            GameObject unit = zombi;

            float distation = Vector3.Distance(agent.transform.position, unit.transform.position);
            if (distation >= MinDistationForAttack)
            {
                agent.destination = unit.transform.position;

            }
            else
            {
                unit.GetComponent<NavMeshAgent>().isStopped = true;

                gameObject.GetComponent<SwordAttack>().isAttack = true;

                agent.isStopped = true;
                isZombi = false;
            }
        }


    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ZombiGo")
        {
            isZombi = true;
            zombi = other.gameObject;
            agent.isStopped = false;

        }
    }



}
