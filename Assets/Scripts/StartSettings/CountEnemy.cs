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

    public GameSettingsSO GameSettingsSO;
    public SaveEnemyDataSO SaveEnemyDataSO;
   

    public List<GameObject> ListEnemy = new List<GameObject>();

    private void Start()
    {
        EnemyDropDown.onValueChanged.AddListener(OnEnemyCountChahged);
        SaveEnemyDataSO._enemyList.Clear();
        SaveEnemyDataSO._enemyColorList.Clear();
    }

    public void CreateEnemyData()
    {
        GameObject[] enemyTag = GameObject.FindGameObjectsWithTag("EnemyUI");
        foreach (GameObject enemy in enemyTag) 
        {
            var name = enemy.GetComponentInChildren<TMP_InputField>().text;
            var color = enemy.transform.Find("ImageButton").GetComponent<Image>().color;

            SaveEnemyDataSO._enemyList.Add(name);
            SaveEnemyDataSO._enemyColorList.Add(color);
        }
        Debug.Log(SaveEnemyDataSO._enemyList.Count);
    }

    private void OnEnemyCountChahged(int index)
    {

        foreach (Transform child in ParentNewEnemy)
        {
            ListEnemy.Clear();
            if (child.tag == "EnemyUI")
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
            enemy.CompareTag("EnemyUI");


            ListEnemy.Add(enemy);

            j++;



        }
        Debug.Log(ListEnemy.Count);

    }
}
