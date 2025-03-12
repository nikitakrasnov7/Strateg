
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildMan : UnitController
{
    public float SpeedMining;
    public float SpeedRepair;
    public float EfficiencyRepair;

    NavMeshAgent agent;


    GameObject Build;
    GameObject Resources;

    public bool isBuild = false;
    public bool isExtractionResources = false;

    public bool isUsingUnit = false;

    //============================= 
    Animator animator;
    Animator resourceAnim;
    AnimatorStateInfo resourceAnimState;

    public ListBuildForResources listBuild;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        listBuild.BuildPosition.Clear();
    }

    private void Update()
    {
        if (isBuild)
        {
            Building();

        }

        if (isExtractionResources)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Tree" || hit.collider.tag == "Rock")
                    {
                        gameObject.GetComponentInChildren<Animator>().SetBool("Going", true);
                        Resources = hit.collider.gameObject;
                        ExtractionResources();
                    }
                }
            }


        }

        if (resourceAnim != null)
        {
            SetAnimAndGoindToBase();
        }
    }

    public void SetAnimAndGoindToBase()
    {
        resourceAnimState = resourceAnim.GetCurrentAnimatorStateInfo(0);
        GameObject build;
        
        //List<GameObject> builds = listBuild.BuildPosition;

        if(resourceAnimState.IsName("Finish"))
        {
            animator.SetBool("Going", true);

            foreach(GameObject go in listBuild.BuildPosition)
            {
                if(go.tag == "Storage")
                {
                    ActivationBuilding(go);
                }
            }
            animator.SetBool("Building", false);
            animator.SetTrigger("EndUnit");



            resourceAnim = null;

        }
    }

    public void RotationUnit()
    {
        Vector3 velocity = agent.velocity;
        if (velocity.sqrMagnitude < 0.1f) return; // ≈сли агент почти не двигаетс€, игнорируем

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        float dotForward = Vector3.Dot(forward, velocity.normalized);
        float dotRight = Vector3.Dot(right, velocity.normalized);

        if (dotForward > 0.7f)
        {
            agent.gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(dotRight, 0, dotForward));
                
        }
        else if (dotForward < -0.7f)
        {
            agent.gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(dotRight, 0, dotForward));

        }
        else if (dotRight > 0)
        {
            agent.gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(dotRight, 0, dotForward));
        }
        else
        {
            agent.gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(dotRight, 0, dotForward));
        }
    }

    public void Building()
    {
        agent.isStopped = false;
        agent.destination = Build.transform.position;
        
        //agent.SetDestination(Build.transform.position);
    }

    public void ExtractionResources()
    {
        agent.isStopped = false;
        RotationUnit();
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


                UnitActionsControllerSO.Instance.AnimUnit = gameObject.GetComponentInChildren<Animator>();
                UnitActionsControllerSO.Instance.StartAnimator(gameObject, "StartBuilding", Build);

                Build = null;
            }

        }
        if (Resources != null)
        {
            if (collision.gameObject.transform.GetInstanceID() == Resources.transform.GetInstanceID())
            {
                agent.isStopped = true;
                isExtractionResources = false;
                animator.SetBool("Building", true);

                resourceAnim = collision.gameObject.GetComponent<Animator>();

                StartCoroutine(TimeForExtraction());




            }
        }


    }


    IEnumerator TimeForExtraction()
    {
        isUsingUnit = false;

        yield return new WaitForSeconds(2);

        animator.SetBool("Going", false);
        animator.SetBool("Building", false);

        animator.SetTrigger("EndUnit");

        Resources.GetComponent<BoxCollider>().enabled = false;
        resourceAnim.SetTrigger("Start");

        yield return new WaitForSeconds(5);
        Destroy(Resources.gameObject);




    }




}
