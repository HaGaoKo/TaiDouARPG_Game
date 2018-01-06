using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemUI : MonoBehaviour {

    UISprite sprite;
    UILabel label;
    public InventoryItem it;

    UISprite Sprite
    {
        get
        {
            if (sprite==null)
            {
                sprite = transform.Find("Sprite").GetComponent<UISprite>();
            }
            return sprite;
        }
    }
    UILabel Label
    {
        get
        {
            if (label==null)
            {
                label = transform.Find("Label").GetComponent<UILabel>();
            }
            return label;
        }
    }

    public void SetInventoryItem(InventoryItem it)
    {
        this.it = it;
        Sprite.spriteName = it.Inventory.Icon;
        if (it.Count <= 1)
        {
            Label.text = "";
        }
        else
        {
            Label.text = it.Count.ToString();
        }
    }

    public void Clear()
    {
        it = null;
        Label.text = "";
        Sprite.spriteName = "bg_道具";
    }

    public void ChangeCount(int count)
    {
        if (it.Count-count<=0)
        {
            Clear();
        }
        else if(it.Count - count == 1)
        {
            label.text = "";
        }
        else
        {
            label.text = (it.Count - count).ToString();
        }
    }

    void OnClick()
    {
        if (it!=null )
        {
            object[] objArray = new object[3];
            objArray[0] = it;
            objArray[1] = true;
            objArray[2] = this;
            transform.parent.parent.parent.SendMessage("OnInventoryClick", objArray);
        }
    }
}
