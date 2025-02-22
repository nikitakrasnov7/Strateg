using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CountEnemy : MonoBehaviour
{
    public TMP_Dropdown EnemyDropDown;
    public Transform ParentNewEnemy;
    public GameObject EnemyPrefab;


    private void Start()
    {
        EnemyDropDown.onValueChanged.AddListener(OnEnemyCountChahged);
    }

    private void OnEnemyCountChahged(int index)
    {
       



        foreach (Transform child in ParentNewEnemy)
        {
            if(child.name != "CountEnemy" && child.name != "Level" && child.name != "SizeMap")
            {
             Destroy(child.gameObject); 

            }
        }
        int enemyCount = EnemyDropDown.value;
        for (int i = 0; i <= enemyCount; i++) 
        {
            int j = 2;
            GameObject enemy = Instantiate(EnemyPrefab, ParentNewEnemy);
            enemy.transform.SetSiblingIndex(j);
            j++;

        }

    }
}
