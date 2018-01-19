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
        EventDelegate.Add(shopButton.onClick, OnShopBtnClick);
        EventDelegate.Add(skillButton.onClick, OnSkillBtnClick);
        EventDelegate.Add(combatButton.onClick, OnCombatBtnClick);
        EventDelegate.Add(settingButton.onClick, OnSettingBtnClick);
        EventDelegate.Add(taskButton.onClick, OnTaskBtnClick);
    }

    void OnBagBtnClick()
    {
        Knapsack._instance.Show();
    }
    void OnShopBtnClick()
    {
        
    }
    void OnSkillBtnClick()
    {
        SkillUI._instance.Show();
    }
    void OnCombatBtnClick()
    {
        
    }
    void OnSettingBtnClick()
    {
        
    }
    void OnTaskBtnClick()
    {
        TaskUI._instance.Show();
    }
}
