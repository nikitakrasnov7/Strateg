
using UnityEngine;
using UnityEngine.UI;

public class ColliderFunctions : MonoBehaviour
{
    Image canvas;

    Color green = Color.green;
    Color red = Color.red;

    //Image Create;


    private void OnCollisionEnter(Collision collision)
    {


        canvas = gameObject.GetComponentInChildren<Image>();
        UnitActionsControllerSO.Instance.CreateButtonController(false);
        canvas.color = red;


    }
    private void OnCollisionExit(Collision collision)
    {
        canvas.color = green;
        UnitActionsControllerSO.Instance.CreateButtonController(true);


    }



}
