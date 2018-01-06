using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    Transform player;

    public Vector3 offSet;

	void Start () {
        player = GameObject.FindWithTag("Player").transform;
	}
	
	void Update () {
        transform.position = player.position + offSet;		
	}
}
