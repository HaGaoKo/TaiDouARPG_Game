using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAutoMove : MonoBehaviour {

    NavMeshAgent agent;

    public float minDistance = 2.5f;

    //public Transform testPos;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent.enabled)
        {
            if (agent.remainingDistance < minDistance)
            {
                agent.isStopped = true;
                agent.enabled = false;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SetDestination(testPos.position);
        //}
    }

    /// <summary>设置目标</summary>
    public void SetDestination(Vector3 targetPos)
    {
        agent.enabled = true;
        agent.SetDestination(targetPos);
    }
}
