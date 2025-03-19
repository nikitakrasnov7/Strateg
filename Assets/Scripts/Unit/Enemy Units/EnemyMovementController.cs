using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    List<float> pointMovementX = new List<float>() { -9, -7, -6, -5, -4, -3, -2, 2, 3, 4, 5, 6, 7 };
    List<float> pointMovementZ = new List<float>() { -9, -7, -6, -5, -4, -3, -2, 2, 3, 4, 5, 6, 7 };

    NavMeshAgent agent;

    Animator animator;



    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        StartCoroutine(EnemyMove());
    }
    float dis;
    Vector3 position;
    IEnumerator EnemyMove()
    {
        while (true)
        {
            float posX = pointMovementX[Random.Range(0, pointMovementX.Count)];
            float posZ = pointMovementZ[Random.Range(0, pointMovementZ.Count)];

            position = new Vector3(gameObject.transform.position.x + posX, 0, gameObject.transform.position.z + posZ);
            if (agent != null)
            {

                agent.destination = position;

            }


            yield return new WaitForSeconds(1f);

        }
    }

    private void Update()
    {
        dis = Vector3.Distance(gameObject.transform.position, position);
        if (dis<=0.024)
        {
            animator.SetBool("Going", false);

        }
        else if (dis>=0.024)
        {
            animator.SetBool("Going", true);

        }
    }
}
