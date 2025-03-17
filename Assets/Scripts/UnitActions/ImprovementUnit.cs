using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImprovementUnit : MonoBehaviour
{
    List<GameObject> unitsList = new List<GameObject>();

    GameObject parentUnitImp;

    List<float> posX = new List<float>() { 7, 6, 5, 4, 3, -3, -4, -5, -6, -7 };
    List<float> posZ = new List<float>() { 7, 6, 5, 4, 3, -3, -4, -5, -6, -7 };

    float timer;



    public void Improvement()
    {
        parentUnitImp = UnitActionsControllerSO.Instance.PrefabWorkoutBuild;

        int countUnit = UIController.Instance.Workout.transform.childCount;

        for (int i = 0; i < countUnit; i++)
        {
            GameObject unitSlot = UIController.Instance.Workout.transform.GetChild(i).gameObject;
            unitsList.Add(unitSlot);
            string countS = unitSlot.GetComponentInChildren<TextMeshProUGUI>().text;
            int count = int.Parse(countS);

            GameObject prefUnit = unitSlot.GetComponentInChildren<WorkoutInformationUnit>().PrefabUnitForWorkout;


            for (int j = 0; j < count; j++)
            {
                
                StartCoroutine(TestWork(prefUnit));


            }

        }
    }

    IEnumerator TestWork(GameObject prefUnit)
    {

        yield return new WaitForSeconds(5);
        UnitActionsControllerSO.Instance.InstantiateNewUnitsWorkout(prefUnit, parentUnitImp, posX[Random.Range(0, posX.Count)], posZ[Random.Range(0, posZ.Count)]);

    }

}
