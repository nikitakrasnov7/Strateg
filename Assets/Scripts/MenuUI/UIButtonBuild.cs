
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class UIButtonBuild : MonoBehaviour
{
    public Building Build;

    public GameObject Prefab;
    private GameObject build;

    public Image ConsentPanel;

    [SerializeField] private bool isActive = true;

    public UnityAction<GameObject> OnButtonClicked;



    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name != "Terrain")
                {
                    UnitActionsControllerSO.Instance.IsMove = false;
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (UnitActionsControllerSO.Instance.PrefabBuild != null)
                        {
                            if (hit.collider.name == UnitActionsControllerSO.Instance.PrefabBuild.gameObject.name)
                            {

                                isActive = true;
                            }

                        }
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        UnitActionsControllerSO.Instance.PrefabBuild.gameObject.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        isActive = false;
                    }
                }
                else UnitActionsControllerSO.Instance.IsMove = true;
            }

        }
        
    }
    public void BuildConstruct()
    {

        UnitActionsControllerSO.Instance.Building(Prefab);

    }


    public void OnClick()
    {
        OnButtonClicked.Invoke(Prefab);
    }
}
