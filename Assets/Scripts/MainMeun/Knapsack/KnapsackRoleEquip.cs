using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackRoleEquip : MonoBehaviour {
    InventoryItem it;
    UISprite _sprite;

    public UISprite _Sprite
    {
        get
        {
            if (_sprite == null)
            {
                _sprite = this.GetComponent<UISprite>();
            }
            return _sprite;
        }

    }

    //public void SetID(int id)
    //{
    //    Inventory inventory = null;
    //    bool isExit = InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);
    //    if (isExit)
    //    {
    //        _Sprite.spriteName = inventory.Icon;
    //    }
    //}

    public void SetInventoryItem(InventoryItem it)
    {
        if (it == null) return;
        this.it = it;
        _Sprite.spriteName = it.Inventory.Icon;

    }

    /// <summary>
    /// 清除身上的装备 亲空格子
    /// </summary>
    public void Clear()
    {
        it = null;
        _Sprite.spriteName = "bg_道具";
    }

    void OnPress(bool isPress)
    {
        if (isPress && it!=null)
        {
            object[] objArray = new object[3];
            objArray[0] = it;
            objArray[1] = false;
            objArray[2] = this;
            transform.parent.parent.SendMessage("OnInventoryClick", objArray);
        }
    }
}
