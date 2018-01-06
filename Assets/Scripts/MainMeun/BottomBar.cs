using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBar : MonoBehaviour {

    UIButton bagButton;
    UIButton shopButton;
    UIButton skillButton;
    UIButton combatButton;
    UIButton settingButton;
    UIButton taskButton;

    private void Awake()
    {
        bagButton = transform.Find("Bag").GetComponent<UIButton>();
        shopButton = transform.Find("Shop").GetComponent<UIButton>();
        skillButton = transform.Find("Skill").GetComponent<UIButton>();
        combatButton = transform.Find("Combat").GetComponent<UIButton>();
        settingButton = transform.Find("Setting").GetComponent<UIButton>();
        taskButton = transform.Find("Task").GetComponent<UIButton>();
    }

    private void Start()
    {
        EventDelegate.Add(bagButton.onClick, OnBagBtnClick);
    }


    void OnBagBtnClick()
    {
        Knapsack._instance.Show();
    }
}
