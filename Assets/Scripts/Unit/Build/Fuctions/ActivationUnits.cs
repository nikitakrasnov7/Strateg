using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivationUnits : MonoBehaviour
{
    Image canvasActivation;

    void Start()
    {

        canvasActivation = gameObject.GetComponentInChildren<Image>();
        canvasActivation.gameObject.SetActive(false);

    }

    private void Update()
    {
        SpriteActivationUnit();
    }
    public void SpriteActivationUnit()
    {
        if (canvasActivation != null)
        {
            if (UnitActionsControllerSO.Instance.RayHitObject != null)
            {
                if (UnitActionsControllerSO.Instance.RayHitObject.name == gameObject.name)
                {
                    canvasActivation.gameObject.SetActive(true);
                }
                else
                {
                    canvasActivation.gameObject.SetActive(false);
                }
            }


        }

    }
}
