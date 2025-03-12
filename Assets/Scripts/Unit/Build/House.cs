
using UnityEngine;

public class House : Builder
{
    public Building TypeBuild;

    private void Update()
    {
        if (UnitActionsControllerSO.Instance.RayHitObject != null)
        {

            if (isReady)
            {
                if (UnitActionsControllerSO.Instance.RayHitObject.gameObject.name == gameObject.name)
                {
                    Debug.Log("выбран построенный объект");
                    UIController.Instance.UiActive(false, false, false, true, false, true);
                }
                //UIController.Instance.UiActive(false, false, false, false, false, false);
            }

        }
    }
}
