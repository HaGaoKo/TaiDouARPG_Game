using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVillageMove : MonoBehaviour {

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
        Vector3 v3 = rig.velocity;

        rig.velocity = new Vector3(-h, v3.y, -v)*speed;

        if (Mathf.Abs(h) >0.05f||Mathf.Abs(v) > 0.05f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-h, 0, -v));
        }
    }
}
