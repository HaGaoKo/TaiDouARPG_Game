using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InventoryPopUp : MonoBehaviour {

    InventoryItem it;
    InventoryItemUI itUI;

    UILabel nameLabel;
    UISprite inventorySprite;
    UILabel desLabel;
    UILabel btnLabel;
    UIButton closeBtn;
    UIButton useBtn;
    UIButton useBatchingBtn;

    private void Awake()
    {
        nameLabel = transform.Find("Bg/NameLabel").GetComponent<UILabel>();
        inventorySprite = transform.Find("Bg/Sprite/Sprite").GetComponent<UISprite>();
        desLabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        btnLabel = transform.Find("Bg/ButtonUserAll/Label").GetComponent<UILabel>();
        closeBtn = transform.Find("Bg/Btn_close").GetComponent<UIButton>();
        useBtn = transform.Find("Bg/ButtonUser").GetComponent<UIButton>();
        useBatchingBtn = transform.Find("Bg/ButtonUserAll").GetComponent<UIButton>();
    }
    private void Start()
    {
        EventDelegate.Add(closeBtn.onClick, OnCloseBtnClick);
        EventDelegate.Add(useBtn.onClick, OnUseBtnClick);
        EventDelegate.Add(useBatchingBtn.onClick, OnUseBatchingBtnClick);
    }

    public void Show(InventoryItem it,InventoryItemUI itUI)
    {
        gameObject.SetActive(true);
        this.it = it;
        this.itUI = itUI;
        nameLabel.text = it.Inventory.Name;
        inventorySprite.spriteName = it.Inventory.Icon;
        desLabel.text = it.Inventory.Des;
        StringBuilder sb = new StringBuilder();
        sb.Append("批量使用(");
        sb.Append(it.Count);
        sb.Append(")");
        btnLabel.text = sb.ToString();
    }

    void OnCloseBtnClick()
    {
        Close();

        transform.parent.SendMessage("DisableButton");
    }

    void OnUseBtnClick()
    {
        itUI.ChangeCount(1);
        PlayerInfo._instance.InventoryUse(it,1);
        OnCloseBtnClick();
    }

    void OnUseBatchingBtnClick()
    {
        itUI.ChangeCount(it.Count);
        PlayerInfo._instance.InventoryUse(it,it.Count);
        OnCloseBtnClick();
    }

    void Clear()
    {
        it = null;
        itUI = null;
    }

    public void Close()
    {
        Clear();
        gameObject.SetActive(false);
    }
}
