
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BuildMan : UnitController
{
    public float SpeedMining;
    public float SpeedRepair;
    public float EfficiencyRepair;

    NavMeshAgent agent;

    Animator animator;
    Animator resourceAnim;

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
            RotationUnit(Build);
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
                    if (hit.collider.tag == "Tree" || hit.collider.tag  == "Rock")
                    {
                        Debug.Log("derevooooo");
                        gameObject.GetComponent<Animator>().SetBool("Going", true);
                        Resources = hit.collider.gameObject;
                        ExtractionResources();
                    }
                }
            }


        }

    }
    
    public void RotationUnit(GameObject obj)
    {
        Vector3 direction = agent.destination - obj.transform.position;
        direction.y = 0f;

        Quaternion rotation = Quaternion.LookRotation(direction);
        agent.gameObject.transform.rotation = rotation;
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
        RotationUnit(Resources);
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

        animator.SetTrigger("EndUnit");
        animator.SetBool("Going", false);
        animator.SetBool("Building", false);

        resourceAnim.SetTrigger("Start");

        yield return new WaitForSeconds(5);
        Destroy(Resources.gameObject);
        StopCoroutine(TimeForExtraction());
        
        


    }




}
