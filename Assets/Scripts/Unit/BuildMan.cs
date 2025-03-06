
using UnityEngine;
using UnityEngine.AI;

public class BuildMan : UnitController
{
    public float SpeedMining;
    public float SpeedRepair;
    public float EfficiencyRepair;

    NavMeshAgent agent;

    Animator animator;

    GameObject Build;

    public bool isBuild = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isBuild)
        {
            Building();
        }
    }


    public void Building()
    {
        agent.destination = Build.transform.position;
    }

    public void ActivationBuilding(GameObject prefab)
    {
        isBuild = true;
        Build = prefab.gameObject; 
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.transform.GetInstanceID() == Build.transform.GetInstanceID())
        {
            agent.isStopped = true;
            isBuild = false;

            animator.SetBool("Building", true);
            Debug.Log("finish");

            UnitActionsControllerSO.Instance.AnimUnit = gameObject.GetComponent<Animator>();
            UnitActionsControllerSO.Instance.StartAnimator(gameObject,"StartBuilding", Build);
        }
    }
}
