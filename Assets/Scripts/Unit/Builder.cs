
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    public InformationUnitSO InformationUnit;

    public float Endurance;
    public float Price;

    public bool isReady;
    private int countEnemy;

    public Building TypeBuild;

    public List<GameObject> unitsPrefworkout;

    private void Update()
    {
        if (UnitActionsControllerSO.Instance.RayHitObject != null)
        {

            if (isReady)
            {
                if (UnitActionsControllerSO.Instance.RayHitObject.gameObject.name == gameObject.name)
                {

                    Debug.Log("Click");

                    UIController.Instance.AddingUnitsForWorkout(unitsPrefworkout);

                    UIController.Instance.UiActive(false, false, false, true, false, true);

                    UnitActionsControllerSO.Instance.PrefabWorkoutBuild = UnitActionsControllerSO.Instance.RayHitObject;

                    UnitActionsControllerSO.Instance.RayHitObject = null;
                }
                //UIController.Instance.UiActive(false, false, false, false, false, false);
            }

        }
    }

    public void DamageBuild(int damage, GameObject enemy)
    {
        countEnemy = 1;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);


        StartCoroutine(Damage(damage, enemy));

    }

    IEnumerator Damage(int damage, GameObject enemy)
    {
        while (countEnemy == 1)
        {
            yield return new WaitForSeconds(5);

            Endurance -= damage;

            if (Endurance <= 0)
            {
                countEnemy = 0;
                enemy.GetComponent<Animator>().SetTrigger("End Attack");
                Destroy(gameObject);

            }
        }



    }



}
