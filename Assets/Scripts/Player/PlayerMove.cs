using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 5;
    Rigidbody rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 nowVel = rig.velocity;
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            rig.velocity = new Vector3(speed * h, nowVel.y, speed * v);
        }
        else
        {
            rig.velocity = new Vector3(0, nowVel.y, 0);
        }
    }
}
