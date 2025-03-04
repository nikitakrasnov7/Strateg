
using UnityEngine;
using UnityEngine.UI;

public class ColliderFunctions : MonoBehaviour
{
    Image canvas;

    Color green = Color.green;
    Color red = Color.red;

    //Image Create;

    private void OnEnable()
    {
        canvas = gameObject.GetComponentInChildren<Image>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (canvas != null)
        {
            UnitActionsControllerSO.Instance.CreateButtonController(false);
            canvas.color = red;
        }


    }
    private void OnCollisionExit(Collision collision)
    {
        if (canvas != null)
        {
            canvas.color = green;
            UnitActionsControllerSO.Instance.CreateButtonController(true);

        }
    }



}
