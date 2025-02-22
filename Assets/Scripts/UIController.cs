using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject BuildCom;
    public GameObject WarriorsCom;
    public GameObject HealerCom;
    public GameObject WorkoutCom;

    public GameObject Build;
    public GameObject Workout;



    private static UIController instance;
    public static UIController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindAnyObjectByType<UIController>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void UiActive(bool buildCom, bool warriorCom, bool healerCom, bool workoutCom, bool build, bool workout)
    {
        BuildCom.SetActive(buildCom);
        WarriorsCom.SetActive(warriorCom);
        HealerCom.SetActive(healerCom);
        WorkoutCom.SetActive(workoutCom);
        Build.SetActive(build);
        Workout.SetActive(workout);

    }



}
