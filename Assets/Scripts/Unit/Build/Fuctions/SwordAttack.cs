using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public bool isAttack = false;
    public bool isCorunine = true;

    public Transform SpawnPointer;
    public GameObject SwordPrefab;

    private bool isNewSword;
    private void Update()
    {
        if (isAttack)
        {
            InstatiateSward();
        }


    }
    
    private void InstatiateSward()
    {
        isAttack = false;
        GameObject sword = Instantiate(SwordPrefab, SpawnPointer);
        sword.transform.localPosition = Vector3.zero;

    }


}
