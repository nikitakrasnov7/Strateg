using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
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
}
