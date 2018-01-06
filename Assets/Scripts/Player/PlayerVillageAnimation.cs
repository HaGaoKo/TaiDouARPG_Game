using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVillageAnimation : MonoBehaviour {

    Animator anim;
    Rigidbody rig;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rig.velocity.magnitude > 0.5f)
        {
            anim.SetBool("Move",true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }

}
