using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVillageAnimation : MonoBehaviour {

    Animator anim;
    Rigidbody rig;
    NavMeshAgent ag;

    //public float v;
    //public Vector3 v3;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        ag = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (rig.velocity.magnitude > 0.1f || ag.enabled)
        {
            anim.SetBool("Move",true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }

}
