
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
    GameObject Resources;

    public bool isBuild = false;
    public bool isExtractionResources = false;

    public bool isUsingUnit = false;

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

        if (isExtractionResources)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.tag == "Tree")
                    {
                        Debug.Log("деревоооооооо");
                        Resources = hit.collider.gameObject;
                        ExtractionResources();
                    }
                }
            }
        }
    }


    public void Building()
    {
        agent.isStopped = false;
        agent.destination = Build.transform.position;
    }

    public void ExtractionResources()
    {   
        agent.isStopped = false;
        agent.destination = Resources.transform.position;
    }


    public void ActivationBuilding(GameObject prefab)
    {
        isBuild = true;
        Build = prefab.gameObject;
    }
    public void ActivationExtractionResources(GameObject resources)
    {
        isExtractionResources = true;
        Resources = resources.gameObject;

    }



    private void OnTriggerEnter(Collider collision)
    {
        if (Build != null)
        {
            if (collision.gameObject.transform.GetInstanceID() == Build.transform.GetInstanceID())
            {
                agent.isStopped = true;
                isBuild = false;
                

                animator.SetBool("Building", true);


                UnitActionsControllerSO.Instance.AnimUnit = gameObject.GetComponent<Animator>();
                UnitActionsControllerSO.Instance.StartAnimator(gameObject, "StartBuilding", Build);

                Build = null;
            }

            if (Resources != null)
            {
                if (collision.gameObject.transform.GetInstanceID() == Resources.transform.GetInstanceID())
                {
                    agent.isStopped = true;
                    isExtractionResources = false;

                    animator.SetBool("Building", true);

                }
            }

        }

    }




}
