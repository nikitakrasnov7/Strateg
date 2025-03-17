using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WorkoutInformationUnit : MonoBehaviour
{
    public GameObject PrefabUnitForWorkout;
    TextMeshProUGUI CountText;
    public int CountUnit = 0;

    private void OnEnable()
    {
        CountText = GetComponentInChildren<TextMeshProUGUI>();
    }


    public void AddingCountUnitWorkout()
    {
        CountUnit++;
        if (CountText != null)
        {

            CountText.text = CountUnit.ToString();
        }
    }


}
