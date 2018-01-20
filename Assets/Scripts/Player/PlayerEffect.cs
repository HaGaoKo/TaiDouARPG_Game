using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour {

    public Renderer[] renderArray;
    public NcCurveAnimation[] curveAnimation;

    private void Start()
    {
        renderArray = GetComponentsInChildren<Renderer>();
        curveAnimation = GetComponentsInChildren<NcCurveAnimation>();
    }

    private void Update()
    {
        //for test
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Show();
        //}
    }

    public void Show()
    {
        foreach (Renderer renderer in renderArray)
        {
            renderer.enabled = true;
        }
        foreach (NcCurveAnimation item in curveAnimation)
        {
            item.ResetAnimation();
        }
    }
}
