
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class RepairUnit : MonoBehaviour
{
    public EventSystem eventSys;
    public Image Build;
    


    


    public void ClickedRepairButton()
    {
        
        if (eventSys.currentSelectedGameObject.name == "Construct")
        {
            UnitActionsControllerSO.Instance.IsBuilding = true;


            Build.gameObject.SetActive(true);

        }
        else
        {
            UnitActionsControllerSO.Instance.IsBuilding = false;
            Build.gameObject.SetActive(false);
        }
    }


}
