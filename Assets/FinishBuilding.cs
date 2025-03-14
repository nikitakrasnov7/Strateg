
using UnityEngine;

public class FinishBuilding : MonoBehaviour
{
    public Animator buildingAnimator;
    private Animator unitAnimator;
    private AnimatorStateInfo animState;
    private void Awake()
    {
        unitAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (buildingAnimator != null)
        {
            SetNewAnimator();
        }
    }
    private void SetNewAnimator()
    {
        animState = buildingAnimator.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName("Finish"))
        {
            unitAnimator.SetBool("Going", false);
            unitAnimator.SetBool("Building", false);
            unitAnimator.SetTrigger("EndUnit");

            if (buildingAnimator.gameObject.GetComponent<Builder>() != null)
            {
                buildingAnimator.gameObject.GetComponent<Builder>().isReady = true;
                    
            }


            buildingAnimator = null;
        }

    }
}
