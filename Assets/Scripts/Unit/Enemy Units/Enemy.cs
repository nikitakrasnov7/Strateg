using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    int hp = 100;

    bool isAttackBuild;

    NavMeshAgent agent;

    Animator animator;

    GameObject build;
    GameObject playerBase;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (UnitActionsControllerSO.Instance.PlayerBase != null)
        {
            playerBase = UnitActionsControllerSO.Instance.PlayerBase;
        }
        build = null;
        isAttackBuild = false;

        agent.destination = playerBase.transform.position;

    }


    private void Update()
    {
        if (isAttackBuild)
        {
            if (build != null)
            {
                float dis = Vector3.Distance(gameObject.transform.position, build.transform.position);

                if (dis <= 8f)
                {
                    animator.SetTrigger("Start Attack");
                    build.GetComponent<Builder>().DamageBuild(25, gameObject);

                    agent.isStopped = true;
                    isAttackBuild = false;
                }


            }
        }
        if (build == null)
        {
            //animator.SetTrigger("End Attack");
            agent.isStopped = false;
            float dis = Vector3.Distance(gameObject.transform.position, playerBase.transform.position);
            if (UnitActionsControllerSO.Instance.PlayerBase != null)
            {
                playerBase = UnitActionsControllerSO.Instance.PlayerBase;
            }

            if (dis <= 8f)
            {
                animator.SetTrigger("Start Attack");
                build.GetComponent<Builder>().DamageBuild(25, gameObject);

                agent.isStopped = true;
                isAttackBuild = false;
            }

            //build = null;
            isAttackBuild = false;

            agent.destination = playerBase.transform.position;
        }


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Build")
        {

            build = other.gameObject;

            isAttackBuild = true;
            agent.destination = build.transform.position;


        }
    }

    public void DamageEnemy(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
