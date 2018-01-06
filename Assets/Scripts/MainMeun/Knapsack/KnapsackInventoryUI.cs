using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackInventoryUI : MonoBehaviour {

    public static KnapsackInventoryUI _instance;
    [SerializeField]
    List<InventoryItemUI> itemList = new List<InventoryItemUI>();//所有的物品格子
    UIButton clearupButton;
    UILabel inventoryLabel;

    ///<summary>当前拥有物品的格子数</summary>
    int count = 0;

    private void Awake()
    {
        _instance = this;
        clearupButton = transform.Find("btn_clearup").GetComponent<UIButton>();
        inventoryLabel = transform.Find("Label").GetComponent<UILabel>();
        int count = transform.Find("Scroll View").childCount;
        Transform t = transform.Find("Scroll View");
        for (int i = 0; i < count; i++)
        {
            itemList.Add(t.transform.Find("item (" + i + ")").GetComponent<InventoryItemUI>());
        }
    }
    private void Start()
    {
        InventoryManager._instance.OnInventoryChanged += OnInventoryChanged;
        EventDelegate.Add(clearupButton.onClick, OnClearUpBtnClick);
    }
    private void OnDestroy()
    {
        InventoryManager._instance.OnInventoryChanged -= OnInventoryChanged;
    }

    void OnInventoryChanged()
    {
        UpdateShow();
    }
    /// <summary>更新显示</summary>
    void UpdateShow()
    {
        int temp = 0;
        for (int i = 0; i < InventoryManager._instance.inventoryItemList.Count; i++)
        {
            InventoryItem it = InventoryManager._instance.inventoryItemList[i];
            if (it.Isdressed==false)
            {
                itemList[temp].SetInventoryItem(it);
                temp++;
            }
        }
        count = temp;
        for (int i = temp; i < itemList.Count; i++)
        {
            itemList[i].Clear();
        }
        inventoryLabel.text = count + "/32";
    }
    /// <summary> 整理 </summary>
    void OnClearUpBtnClick()
    {
        UpdateShow();
    }
    /// <summary> 背包中物品数量的更新 </summary>
    void UpdateCount()
    {
        count = 0;
        foreach (InventoryItemUI itUI in itemList)
        {
            if (itUI.it != null)
            {
                count++;
            }
        }
        inventoryLabel.text = count + "/32";
    }

    /// <summary> 装备加入背包 </summary>
    public void AddInventoryItem(InventoryItem it)
    {
        foreach (InventoryItemUI itUI in itemList)
        {
            if (itUI.it == null)
            {
                itUI.SetInventoryItem(it);
                count++;
                break;
            }
        }
        inventoryLabel.text = count + "/32";
    }
}
