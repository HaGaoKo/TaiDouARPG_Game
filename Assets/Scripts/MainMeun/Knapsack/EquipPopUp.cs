using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPopUp : MonoBehaviour {

    public PowerShow powerShow;
    InventoryItem it;
    InventoryItemUI itUI;
    KnapsackRoleEquip roleEquip;

    UISprite equipSprite;
    UILabel nameLabel;
    UILabel levelLabel;
    UILabel qualityLabel;
    UILabel damageLabel;
    UILabel hpLabel;
    UILabel powerLabel;
    UILabel desLabel;
    UIButton closeBtn;
    UIButton equipBtn;
    UILabel btnLabel;
    UIButton upgradeBtn;

    bool isLeft = true;

    private void Awake()
    {
        equipSprite = transform.Find("EquipBg/Sprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("LevelLabel/Label").GetComponent<UILabel>();
        qualityLabel = transform.Find("QualityLabel/Label").GetComponent<UILabel>();
        damageLabel = transform.Find("DamageLabel/Label").GetComponent<UILabel>();
        hpLabel = transform.Find("HpLabel/Label").GetComponent<UILabel>();
        powerLabel = transform.Find("PowerLabel/Label").GetComponent<UILabel>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();
        closeBtn = transform.Find("Btn_close").GetComponent<UIButton>();
        equipBtn = transform.Find("EquipButton").GetComponent<UIButton>();
        btnLabel = equipBtn.transform.GetComponentInChildren<UILabel>();
        upgradeBtn = transform.Find("UpGradeButton").GetComponent<UIButton>();
    }
    private void Start()
    {
        EventDelegate.Add(closeBtn.onClick,OnCloseBtnClick);
        EventDelegate.Add(equipBtn.onClick,OnEquipBtnClick);
        EventDelegate.Add(upgradeBtn.onClick, OnUpGradeButtonClick);
    }

    /// <summary>UI刷新 </summary>
    public void Show(InventoryItem it,InventoryItemUI itUI,KnapsackRoleEquip roleEquip, bool isLeft = true)
    {
        gameObject.SetActive(true);
        this.it = it;
        this.itUI = itUI;
        this.roleEquip = roleEquip;
        this.isLeft = isLeft;
        Vector3 pos = transform.localPosition;
        if (isLeft)
        {
            transform.localPosition = new Vector3(-Mathf.Abs(pos.x), pos.y, pos.z);
            btnLabel.text = "装备";
        }
        else
        {
            transform.localPosition = new Vector3(Mathf.Abs(pos.x), pos.y, pos.z);
            btnLabel.text = "卸下";
        }
        equipSprite.spriteName = it.Inventory.Icon;
        nameLabel.text = it.Inventory.Name;
        levelLabel.text = it.Level.ToString();
        qualityLabel.text = it.Inventory.Quality.ToString();
        damageLabel.text = it.Inventory.Damage.ToString();
        hpLabel.text = it.Inventory.Hp.ToString();
        powerLabel.text = it.Inventory.Power.ToString();
        desLabel.text = it.Inventory.Des;
    }
    
    /// <summary>关闭按钮 </summary>
    void OnCloseBtnClick()
    {
        Close();
        //向出售按钮发送消息 禁用出售按钮
        transform.parent.SendMessage("DisableButton");
    }
    /// <summary>装备和卸下按钮 </summary>
    void OnEquipBtnClick()
    {
        int startValue = PlayerInfo._instance.GetOverallPower();
        if (isLeft)//装备
        {
            itUI.Clear();//清空背包中装备的格子
            PlayerInfo._instance.DressOn(it);
        }
        else//卸下
        {
            roleEquip.Clear();//清空身上的装备的格子
            PlayerInfo._instance.DressOff(it);
        }
        OnCloseBtnClick();
        int endValue = PlayerInfo._instance.GetOverallPower();
        powerShow.ShowPowerChange(startValue, endValue);

        KnapsackInventoryUI._instance.SendMessage("UpdateCount");
    }
    /// <summary>装备升级按钮的点击 </summary>
    void OnUpGradeButtonClick()
    {
        int coinNeed = (it.Level + 1) * it.Inventory.Price;
        bool isSuccess = PlayerInfo._instance.GetCoin(coinNeed);
        if (isSuccess)
        {
            it.Level++;
            levelLabel.text = it.Level.ToString();
        }
        else
        {
            //提示信息
            MessageManage._instance.ShowMessage("金币不足，无法升级!", 0.5f);
        }
    }
    /// <summary>清空 </summary>
    void ClearObject()
    {
        it = null;
        itUI = null;
    }

    /// <summary>关闭弹窗</summary>
    public void Close()
    {
        ClearObject();
        this.gameObject.SetActive(false);
    }
}
