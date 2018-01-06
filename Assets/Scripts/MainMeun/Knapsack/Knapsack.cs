using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : MonoBehaviour {
    public static Knapsack _instance;

    EquipPopUp equipPopUp;
    InventoryPopUp inventoryPopUp;

    UIButton saleButton;
    UILabel priceLabel;

    UIButton closeBtn;

    InventoryItemUI itUI;

    TweenPosition tween;

    private void Awake()
    {
        _instance = this;
        tween = GetComponent<TweenPosition>();
        closeBtn = transform.Find("Btn_close").GetComponent<UIButton>();
        equipPopUp = transform.Find("EquipPopUp").GetComponent<EquipPopUp>();
        inventoryPopUp = transform.Find("InventoryPopUp").GetComponent<InventoryPopUp>();
        saleButton = transform.Find("Inventory/btn_sale").GetComponent<UIButton>();
        priceLabel = transform.Find("Inventory/PriceBg/Label").GetComponent<UILabel>();
        DisableButton();
        priceLabel.text = "";
    }
    private void Start()
    {
        EventDelegate.Add(saleButton.onClick, OnSaleBtnClick);
        EventDelegate.Add(closeBtn.onClick, Hide);
    }

    /// <summary>出售按钮不可用</summary>
    void DisableButton()
    {
        saleButton.SetState(UIButtonColor.State.Disabled, true);
        saleButton.GetComponent<BoxCollider>().enabled = false;
        priceLabel.text = "";
    }
    void EnalableButton()
    {
        saleButton.SetState(UIButtonColor.State.Normal, true);
        saleButton.GetComponent<BoxCollider>().enabled = true;
    }
    /// <summary>物品出售</summary>
    void OnSaleBtnClick()
    {
        int price = int.Parse(priceLabel.text);
        PlayerInfo._instance.AddCoin(price);

        InventoryManager._instance.RemoveInventoryItem(itUI.it);
        itUI.Clear();

        equipPopUp.Close();
        inventoryPopUp.Close();

        DisableButton();
        
        
    }

    public void Show()
    {
        tween.PlayForward();
    }
    public void Hide()
    {
        tween.PlayReverse();
    }

    public void OnInventoryClick(object[] obj)
    {
        InventoryItem it = obj[0] as InventoryItem;
        bool isLeft = (bool)obj[1];

        if (it.Inventory.InventoryType == InventoryType.Equip)
        {
            InventoryItemUI itUI = null;
            KnapsackRoleEquip roleEquip = null;
            if (isLeft)
            {
                itUI = obj[2] as InventoryItemUI;
            }
            else
            {

                roleEquip = obj[2] as KnapsackRoleEquip;
            }
            equipPopUp.Show(it, itUI,roleEquip, isLeft);
        }
        else 
        {
            InventoryItemUI itUI = obj[2] as InventoryItemUI;
            inventoryPopUp.Show(it,itUI);
        }

        //TODO 优化 出售全部
        if((it.Inventory.InventoryType == InventoryType.Equip && isLeft)|| it.Inventory.InventoryType != InventoryType.Equip)
        {
            this.itUI = obj[2] as InventoryItemUI;
            EnalableButton();
            priceLabel.text = (itUI.it.Inventory.Price * itUI.it.Count).ToString();
        }
    }
}
