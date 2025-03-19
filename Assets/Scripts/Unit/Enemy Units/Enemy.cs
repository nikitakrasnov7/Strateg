using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    int hp = 100;

    NavMeshAgent agent;

    GameObject playerBase;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        if (UnitActionsControllerSO.Instance.PlayerBase != null)
        {
            playerBase = UnitActionsControllerSO.Instance.PlayerBase;
        }

        agent.destination = playerBase.transform.position;

    }

    public void DamageEnemy(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;

            if(hp <= 0)
            {
                Destroy(gameObject); 
            }
        }
    }
}
