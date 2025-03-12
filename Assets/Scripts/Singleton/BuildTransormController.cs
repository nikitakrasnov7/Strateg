using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTransormController : MonoBehaviour
{
    private static BuildTransormController instance;

    public static BuildTransormController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<BuildTransormController>();

            }
            return instance;
        }
    }

    GameObject prefabBuild;
    public GameObject PrefabBuild { get { return prefabBuild; } set { prefabBuild = value; } }

    public void TransormBuild()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (UnitActionsControllerSO.Instance.PrefabBuild != null)
                {
                    if (hit.collider.name == UnitActionsControllerSO.Instance.PrefabBuild.name)
                    {
                        UnitActionsControllerSO.Instance.IsMove = false;

                        if (touch.phase == TouchPhase.Moved)
                        {
                            UnitActionsControllerSO.Instance.PrefabBuild.gameObject.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                            Debug.Log(UnitActionsControllerSO.Instance.PrefabBuild.transform.position);
                        }

                    }
                    else UnitActionsControllerSO.Instance.IsMove = true;
                }

            }

        }
    }

    private void Update()
    {
       
        if (UnitActionsControllerSO.Instance.RayHitObject != null)
        {

            prefabBuild = UnitActionsControllerSO.Instance.RayHitObject.gameObject;
            TransormBuild();
        }

    }



}
