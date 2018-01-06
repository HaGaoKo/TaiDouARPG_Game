using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackRole : MonoBehaviour
{
    UILabel nameLabel;

    KnapsackRoleEquip helmEquip;
    KnapsackRoleEquip closhEquip;
    KnapsackRoleEquip weaponEquip;
    KnapsackRoleEquip shoseEquip;
    KnapsackRoleEquip necklackEquip;
    KnapsackRoleEquip braceletEquip;
    KnapsackRoleEquip ringEquip;
    KnapsackRoleEquip wingEquip;

    UILabel hpLabel;
    UILabel damagLabel;
    UILabel expLabel;
    UISlider expSlider;

    private void Awake()
    {
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        helmEquip = transform.Find("HelmSprite").GetComponent<KnapsackRoleEquip>();
        closhEquip = transform.Find("CloseSprite ").GetComponent<KnapsackRoleEquip>();
        weaponEquip = transform.Find("WeaponSprite").GetComponent<KnapsackRoleEquip>();
        shoseEquip = transform.Find("ShoseSprite").GetComponent<KnapsackRoleEquip>();
        necklackEquip = transform.Find("NeckLaceSprite").GetComponent<KnapsackRoleEquip>();
        braceletEquip = transform.Find("BraceletSprite").GetComponent<KnapsackRoleEquip>();
        ringEquip = transform.Find("RingSprite").GetComponent<KnapsackRoleEquip>();
        wingEquip = transform.Find("WingSprite").GetComponent<KnapsackRoleEquip>();
        hpLabel = transform.Find("HpBg/Label").GetComponent<UILabel>();
        damagLabel = transform.Find("DamageBg/Label").GetComponent<UILabel>();
        expLabel = transform.Find("ExpBg/ExpSlider/Label").GetComponent<UILabel>();
        expSlider = transform.Find("ExpBg/ExpSlider").GetComponent<UISlider>();
    }

    private void Start()
    {
        PlayerInfo._instance.OnPlayerInfoChanged += OnPlayerInfoChanged;
    }
    private void OnDestroy()
    {
        PlayerInfo._instance.OnPlayerInfoChanged -= OnPlayerInfoChanged;
    }
    void OnPlayerInfoChanged(InfoType type)
    {
        if(type== InfoType.All||type == InfoType.Hp||type== InfoType.Damage||type== InfoType.Exp||type == InfoType.Equip)
        {
            UpdateShow();
        }
    }

    void UpdateShow()
    {
        PlayerInfo info = PlayerInfo._instance;

        //helmEquip.SetID(info.HelmID);
        //closhEquip.SetID(info.CloshID);
        //weaponEquip.SetID(info.WeaponID);
        //shoseEquip.SetID(info.ShoesID);
        //necklackEquip.SetID(info.NecklaceID);
        //braceletEquip.SetID(info.BraceletID);
        //ringEquip.SetID(info.RingID);
        //wingEquip.SetID(info.WingID);

        helmEquip.SetInventoryItem(info.HelmInventory);
        closhEquip.SetInventoryItem(info.CloshInventory);
        weaponEquip.SetInventoryItem(info.WeaponInventory);
        shoseEquip.SetInventoryItem(info.ShoesInventory);
        necklackEquip.SetInventoryItem(info.NecklaceInventory);
        braceletEquip.SetInventoryItem(info.BraceletInventory);
        ringEquip.SetInventoryItem(info.RingInventory);
        wingEquip.SetInventoryItem(info.WingInventory);

        hpLabel.text = info.Hp.ToString();
        damagLabel.text = info.Damage.ToString();
        expSlider.value = (float)info.Exp / GameController.GetRequilerExpByLevel(info.Level + 1);
        expLabel.text = info.Exp + "/" + GameController.GetRequilerExpByLevel(info.Level + 1);
    }
}
