using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem  {

    Inventory inventory;
    int level;
    int count;
    bool isdressed = false;//是否穿戴

    #region get set func
    public Inventory Inventory
    {
        get
        {
            return inventory;
        }

        set
        {
            inventory = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public int Count
    {
        get
        {
            return count;
        }

        set
        {
            count = value;
        }
    }
    /// <summary>装备是否穿戴</summary>
    public bool Isdressed
    {
        get
        {
            return isdressed;
        }

        set
        {
            isdressed = value;
        }
    }
    #endregion
}
