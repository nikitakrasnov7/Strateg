using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    private bool isNewSword;
    private void Update()
    {

        gameObject.transform.Translate(0, 0, -0.1f);

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Zombi")
        {
            gameObject.transform.parent.GetComponentInParent<SwordAttack>().isAttack = true;
            Destroy(gameObject);
        }
        


    }

}
