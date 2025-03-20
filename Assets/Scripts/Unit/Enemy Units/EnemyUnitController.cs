using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyUnitController : MonoBehaviour
{
    public GameObject PrefabEnemy;

    public List<GameObject> ListPointer = new List<GameObject>();


    private void OnEnable()
    {
        StartCoroutine(CreatingEnemy());
    }


    IEnumerator CreatingEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            GameObject enemy = Instantiate(PrefabEnemy);
            enemy.transform.position = ListPointer[Random.Range(0, ListPointer.Count)].transform.position;
            enemy.transform.parent = gameObject.transform;
        }

    }
}
