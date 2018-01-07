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
            if (agent.remainingDistance < minDistance && agent.remainingDistance!=0)
            {
                agent.isStopped = true;
                agent.enabled = false;
                TaskManager._instance.OnArriveDestination();
            }
        }
        //如果在寻路过程中按下移动键，停止自动寻路
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            StopAuto();
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
    /// <summary>停止自动寻路</summary>
    public void StopAuto()
    {
        if (agent.enabled)
        {
            agent.isStopped = true;
            agent.enabled = false;
        }
    }
}
