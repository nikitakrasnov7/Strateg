using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FinishBuilding : MonoBehaviour
{
    public Animator buildingAnimator;
    private Animator unitAnimator;
    private AnimatorStateInfo animState;
    private void Awake()
    {
        unitAnimator = GetComponent<Animator>();
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
            buildingAnimator = null;
        }
        
    }
}
