using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscriptManager : MonoBehaviour {

    public static TranscriptManager _instance;

    public GameObject player;

    private void Awake()
    {
        _instance = this;
        player = GameObject.FindWithTag("Player").gameObject;
    }

    private void Start()
    {
    }
}
