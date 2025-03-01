using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;

public class UIButtonBuild : MonoBehaviour
{
    public Building Build;

    public GameObject Prefab;
    private GameObject build;

    //public Image ImageIsBuild;

    [SerializeField] private bool isActive = true;

    public UnityAction<GameObject> OnButtonClicked;


    public void BuildConstruct()
    {
        if (UnitActionsControllerSO.Instance.IsBuilding)
        {

            //ImageIsBuild.gameObject.SetActive(true);

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

                    build.transform.position = test;


                }
            }

        }
    }
    private void Update()
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
                    if (hit.collider.name == build.name) 
                    {
                        isActive = true;
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


    public void OnClick()
    {
        OnButtonClicked.Invoke(Prefab);
    }
}
