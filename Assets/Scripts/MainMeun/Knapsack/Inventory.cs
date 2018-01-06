using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>物品类型</summary>
public enum InventoryType
{
    Equip,
    Drug,
    /// <summary>宝箱</summary>
    Box 
}

/// <summary>装备类型 </summary>
public enum EquipType
{
    ///<summary>头盔 </summary>
    Helm,
    ///<summary>衣服 </summary>
    Cloth,
    ///<summary>武器 </summary>
    Weapon,
    ///<summary>鞋子 </summary>
    Shoes,
    ///<summary>项链 </summary>
    Necklace,
    ///<summary>手镯 </summary>
    Bracelet,
    ///<summary>戒子 </summary>
    Ring,
    ///<summary>翅膀 </summary>
    Wing
}

public class Inventory{

    #region 属性
    int id;//ID
    string name;//名称
    string icon;    //图集中的名称
    InventoryType inventoryType;//类型
    EquipType equipType;    //装备类型
    //int level = 1;//装备等级
    //int count = 1;//物品个数
    int price = 0;//物品价格
    int starLevel = 1;//星级
    int quality = 1;//品质
    int damage = 0;//伤害
    int hp = 0;//生命
    int power = 0;//战斗力
    InfoType InfoType;//作用类型，表示作用在那个属性上
    int applyValue;//作用值
    string des;//描述
    #endregion

    #region get set func
    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    public InventoryType InventoryType
    {
        get
        {
            return inventoryType;
        }

        set
        {
            inventoryType = value;
        }
    }

    public EquipType EquipType
    {
        get
        {
            return equipType;
        }

        set
        {
            equipType = value;
        }
    }

    //public int Level
    //{
    //    get
    //    {
    //        return level;
    //    }

    //    set
    //    {
    //        level = value;
    //    }
    //}

    //public int Count
    //{
    //    get
    //    {
    //        return count;
    //    }

    //    set
    //    {
    //        count = value;
    //    }
    //}

    public int Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    public int StarLevel
    {
        get
        {
            return starLevel;
        }

        set
        {
            starLevel = value;
        }
    }

    public int Quality
    {
        get
        {
            return quality;
        }

        set
        {
            quality = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
        }
    }

    public InfoType InfoType1
    {
        get
        {
            return InfoType;
        }

        set
        {
            InfoType = value;
        }
    }

    public int ApplyValue
    {
        get
        {
            return applyValue;
        }

        set
        {
            applyValue = value;
        }
    }

    public string Des
    {
        get
        {
            return des;
        }

        set
        {
            des = value;
        }
    }
    #endregion get set 


}
