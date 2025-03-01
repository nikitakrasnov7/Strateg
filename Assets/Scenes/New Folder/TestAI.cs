using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestAI : MonoBehaviour
{
    NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float distance = Vector3.Distance(agent.destination, hit.point);
                if (distance > 0.5f)
                { agent.destination = hit.point; }
            }
        }
    }
}
