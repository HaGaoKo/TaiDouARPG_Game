using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 5;
    Rigidbody rig;
    Animator anim;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 nowVel = rig.velocity;
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            anim.SetBool("Move", true);
            if (anim.GetCurrentAnimatorStateInfo(1).IsName("Empty"))
            {
                rig.velocity = new Vector3(speed * h, nowVel.y, speed * v);
                transform.LookAt(new Vector3(h, 0, v) + transform.position);
            }
            else
            {
                rig.velocity = new Vector3(0, nowVel.y, 0);
            }
        }
        else
        {
            anim.SetBool("Move", false);
            rig.velocity = new Vector3(0, nowVel.y, 0);
        }
    }
}
