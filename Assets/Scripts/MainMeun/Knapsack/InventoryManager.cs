using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public static InventoryManager _instance;

    public TextAsset listInfo;
    public Dictionary<int, Inventory> inventoryDict = new Dictionary<int, Inventory>();
    //public Dictionary<int, InventoryItem> inventoryItemDict = new Dictionary<int, InventoryItem>();
    public List<InventoryItem> inventoryItemList = new List<InventoryItem>();

    public delegate void OnInventoryChangeEvent();
    public event OnInventoryChangeEvent OnInventoryChanged;

    private void Awake()
    {
        _instance = this;
        ReadInventoryInfo();
        
    }
    private void Start()
    {
        ReadInventoryItemInfo();
    }

    void ReadInventoryInfo()
    {
        string[] itemStrArray = listInfo.text.Split('\n');
        foreach (string item in itemStrArray)
        {
            //ID 名称 图标 类型（Equip，Drug） 装备类型 售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述
            string[] proArray = item.Split('|');
            Inventory inventory = new Inventory
            {
                Id = int.Parse(proArray[0]),
                Name = proArray[1],
                Icon = proArray[2],
            };
            switch (proArray[3])
            {
                case "Equip":
                    inventory.InventoryType = InventoryType.Equip;
                    break;
                case "Drug":
                    inventory.InventoryType = InventoryType.Drug;
                    break;
                case "Box":
                    inventory.InventoryType = InventoryType.Box;
                    break;
            }
            if(inventory.InventoryType== InventoryType.Equip)
            {
                switch (proArray[4])
                {
                    case "Helm":
                        inventory.EquipType = EquipType.Helm;
                        break;
                    case "Cloth":
                        inventory.EquipType = EquipType.Cloth;
                        break;
                    case "Shoes":
                        inventory.EquipType = EquipType.Shoes;
                        break;
                    case "Weapon":
                        inventory.EquipType = EquipType.Weapon;
                        break;
                    case "Bracelet":
                        inventory.EquipType = EquipType.Bracelet;
                        break;
                    case "Necklace":
                        inventory.EquipType = EquipType.Necklace;
                        break;
                    case "Ring":
                        inventory.EquipType = EquipType.Ring;
                        break;
                    case "Wing":
                        inventory.EquipType = EquipType.Wing;
                        break;
                    default:
                        break;
                }
            }
            inventory.Price = int.Parse(proArray[5]);
            if (inventory.InventoryType == InventoryType.Equip)
            {
                inventory.StarLevel = int.Parse(proArray[6]);
                inventory.Quality = int.Parse(proArray[7]);
                inventory.Damage = int.Parse(proArray[8]);
                inventory.Hp = int.Parse(proArray[9]);
                inventory.Power = int.Parse(proArray[10]);
            }
            if (inventory.InventoryType == InventoryType.Drug)
            {
                inventory.ApplyValue = int.Parse(proArray[12]);
            }
            inventory.Des = proArray[13];
            inventoryDict.Add(inventory.Id, inventory);
        }
    }
    /// <summary>完成角色背包信息的初始化，获得拥有的物品 </summary>
    void ReadInventoryItemInfo()
    {   //需要连接服务器 取得当前角色拥有的物品信息

        //随机生成主角拥有的物品
        for (int i = 0; i < 13; i++)
        {
            int id = Random.Range(1001, 1020);
            Inventory inv = null;
            inventoryDict.TryGetValue(id, out inv);
            if(inv.InventoryType== InventoryType.Equip)
            {
                InventoryItem it = new InventoryItem
                {
                    Inventory = inv,
                    Level = Random.Range(1, 11),
                    Count = 1
                };
                inventoryItemList.Add(it);
            }
            else
            {//先判断背包中是否存在
                InventoryItem it = null;
                bool isExit = false;
                foreach (InventoryItem item in inventoryItemList)
                {
                    if (item.Inventory.Id==id)
                    {
                        isExit = true;
                        it = item;
                        break;
                    }
                }
                if (isExit)
                {
                    it.Count++;
                }
                else
                {
                    it = new InventoryItem
                    {
                        Inventory = inv,
                        Count = 1,
                    };
                    inventoryItemList.Add(it);
                }
            }
        }
        OnInventoryChanged();
    }

    public void RemoveInventoryItem(InventoryItem it)
    {
        this.inventoryItemList.Remove(it);
    }
}
