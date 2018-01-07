using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVillageMove : MonoBehaviour {

    public float speed = 5;
    Rigidbody rig;
    NavMeshAgent ag;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        ag = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 v3 = rig.velocity;
        
        if (Mathf.Abs(h) >0.05f||Mathf.Abs(v) > 0.05f)
        {
            rig.velocity = new Vector3(-h * speed, v3.y, -v * speed);
            transform.rotation = Quaternion.LookRotation(new Vector3(-h, 0, -v));
        }
        else
        {
            if (!ag.enabled)
            {
                rig.velocity = Vector3.zero;
            }
        }

        if (ag.enabled)
        {
            transform.rotation = Quaternion.LookRotation(ag.velocity);
        }
    }
}
