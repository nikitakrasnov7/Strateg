
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
        if (UnitActionsControllerSO.Instance.IsBuilding)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (touch.phase == TouchPhase.Began)
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (build != null)
                        {
                            if (hit.collider.name == build.name)
                            {
                                isActive = true;
                            }

                        }

                    }
                }

                if (touch.phase == TouchPhase.Moved)
                {


                    if (Physics.Raycast(ray, out hit))
                    {
                        if (isActive)
                        {
                            build.transform.position = new Vector3(hit.point.x, 0, hit.point.z);

                        }
                    }
                }


                if (touch.phase == TouchPhase.Ended)
                {
                    isActive = false;
                }
            }
        }

    }
    public void BuildConstruct()
    {
        if (UnitActionsControllerSO.Instance.IsBuilding)
        {


            Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            Ray ray = Camera.main.ScreenPointToRay(center);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.point);
                if (hit.collider.name == "Terrain")
                {
                    var test = hit.point;
                    build = null;

                    build = Instantiate(Prefab);
                    UnitActionsControllerSO.Instance.PrefabBuild = build.gameObject;
                    build.AddComponent<ColliderFunctions>();

                    build.transform.position = test;


                    if (UnitActionsControllerSO.Instance.PanelCreate != null)
                    {

                        UnitActionsControllerSO.Instance.CreatePanelController(true);
                    }


                }
            }

        }
    }


    public void OnClick()
    {
        OnButtonClicked.Invoke(Prefab);
    }
}
