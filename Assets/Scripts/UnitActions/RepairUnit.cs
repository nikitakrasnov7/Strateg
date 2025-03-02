
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RepairUnit : MonoBehaviour
{
    public EventSystem eventSys;
    public Image Build;
    public Image CreatePanelImage;
    public Image CreateButton;
    





    public void ClickedRepairButton()
    {
        if (eventSys.currentSelectedGameObject.name == "Construct")
        {
            UnitActionsControllerSO.Instance.IsBuilding = true;
            UnitActionsControllerSO.Instance.PanelCreate = CreatePanelImage;
            UnitActionsControllerSO.Instance.CreateButton = CreateButton;

            Build.gameObject.SetActive(true);

        }
        else
        {
            UnitActionsControllerSO.Instance.IsBuilding = false;
            Build.gameObject.SetActive(false);
        }
    }
   

}
