
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Globalization;

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
