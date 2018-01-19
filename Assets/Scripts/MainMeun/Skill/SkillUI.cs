using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour {

    public static SkillUI _instance;

    UILabel nameLabel;
    UILabel desLabel;
    UIButton closeBtn;
    UIButton upgradeBtn;
    UILabel upgradeLabel;

    Skill skill;
    TweenPosition tween;

    private void Awake()
    {
        _instance = this;
        tween = GetComponent<TweenPosition>();
        nameLabel = transform.Find("Bg/SkillNameLabel").GetComponent<UILabel>();
        desLabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        closeBtn = transform.Find("Btn_close").GetComponent<UIButton>();
        upgradeBtn = transform.Find("Bg/UpgradeButton").GetComponent<UIButton>();
        upgradeLabel = upgradeBtn.GetComponentInChildren<UILabel>();

        nameLabel.text = "";
        desLabel.text = "";
        DisableUpgradeButton("选择技能");

    }

    private void Start()
    {
        EventDelegate.Add(upgradeBtn.onClick, OnUpgradeButtonClick);
        EventDelegate.Add(closeBtn.onClick, OnClose);
    }

    void DisableUpgradeButton(string label = "")
    {
        upgradeBtn.SetState(UIButton.State.Disabled, true);
        upgradeBtn.GetComponent<Collider>().enabled = false;
        if (label != "")
        {
            upgradeLabel.text = label;
        }
    }
    void EnableUpgradeButton(string label = "")
    {
        upgradeBtn.SetState(UIButton.State.Normal, true);
        upgradeBtn.GetComponent<Collider>().enabled = true;
        if (label != "")
        {
            upgradeLabel.text = label;
        }
    }

    void OnSkillClick(Skill skill)
    {
        this.skill = skill;
        PlayerInfo info = PlayerInfo._instance;
        //print(info.Coin);
        if((500 * (skill.Level + 1)) <= info.Coin)
        {
            if (skill.Level < info.Level)
            {
                EnableUpgradeButton("升级");
            }
            else
            {
                DisableUpgradeButton("人物等级不足");
            }
        }
        else
        {
            DisableUpgradeButton("金币不足");
        }
        nameLabel.text = skill.Name + "Lv." + skill.Level;
        desLabel.text = "当前技能的攻击力为" + (skill.Damage * skill.Level) + "    下一级技能的攻击力为:" + (skill.Damage * (skill.Level + 1)) + "     升级所需要的金币数：" + (500 * (skill.Level + 1));
    }

    void OnUpgradeButtonClick()
    {
        PlayerInfo info = PlayerInfo._instance;
        if (skill.Level <= info.Level)
        {
            int coinNeed = 500 * (skill.Level + 1);
            bool isSuccess = info.GetCoin(coinNeed);
            if (isSuccess)
            {
                skill.Upgrade();
                OnSkillClick(skill);
            }
            else
            {
                DisableUpgradeButton("金币不足");
            }
        }
        else
        {
            DisableUpgradeButton("人物等级不足");
        }

    }

    void OnClose()
    {
        Hide();
    }

    public void Show()
    {
        tween.PlayForward();
        OnSkillClick(skill);
    }
    public void Hide()
    {
        tween.PlayReverse();
    }
}
