using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InfoType
{
    Name,
    HeadPortarit,
    Level,
    Power,
    Exp,
    Diamond,
    Coin,
    Energy,
    Toughen,
    Hp,
    Damage,
    Equip,
    All
}

public class PlayerInfo : MonoBehaviour {

    public static PlayerInfo _instance;

    #region property
    private string _name;
    private string _headPortrait;
    private int _livel = 1;
    private int _power = 0;
    private int _exp = 0;
    private int _diamond = 0;
    private int _coin = 0;
    private int _energy = 0;
    private int _toughen = 0;
    private int _hp;
    private int _damage;
    //private int _helmID=0;
    //private int _closhID=0;
    //private int _weaponID=0;
    //private int _shoesID=0;
    //private int _necklaceID=0;
    //private int _braceletID=0;
    //private int _ringID=0;
    //private int _wingID=0;

    private InventoryItem _helmInventory;
    private InventoryItem _closhInventory;
    private InventoryItem _weaponInventory;
    private InventoryItem _shoesInventory;
    private InventoryItem _necklaceInventory;
    private InventoryItem _braceletInventory;
    private InventoryItem _ringInventory;
    private InventoryItem _wingInventory;
    #endregion

    public float energyTime = 0;
    public float toughenTime = 0;

    public delegate void OnplayerInfoChangedEvent(InfoType type);
    public event OnplayerInfoChangedEvent OnPlayerInfoChanged;

    #region get set methd
    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public string HeadPortrait
    {
        get
        {
            return _headPortrait;
        }

        set
        {
            _headPortrait = value;
        }
    }

    public int Level
    {
        get
        {
            return _livel;
        }

        set
        {
            _livel = value;
        }
    }

    public int Power
    {
        get
        {
            return _power;
        }

        set
        {
            _power = value;
        }
    }

    public int Exp
    {
        get
        {
            return _exp;
        }

        set
        {
            _exp = value;
        }
    }

    public int Diamond
    {
        get
        {
            return _diamond;
        }

        set
        {
            _diamond = value;
        }
    }

    public int Coin
    {
        get
        {
            return _coin;
        }

        set
        {
            _coin = value;
        }
    }

    public int Energy
    {
        get
        {
            return _energy;
        }

        set
        {
            _energy = value;
        }
    }

    public int Toughen
    {
        get
        {
            return _toughen;
        }

        set
        {
            _toughen = value;
        }
    }

    public int Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
        }
    }

    public int Damage
    {
        get
        {
            return _damage;
        }

        set
        {
            _damage = value;
        }
    }

    public InventoryItem HelmInventory
    {
        get
        {
            return _helmInventory;
        }

        set
        {
            _helmInventory = value;
        }
    }

    public InventoryItem CloshInventory
    {
        get
        {
            return _closhInventory;
        }

        set
        {
            _closhInventory = value;
        }
    }

    public InventoryItem WeaponInventory
    {
        get
        {
            return _weaponInventory;
        }

        set
        {
            _weaponInventory = value;
        }
    }

    public InventoryItem ShoesInventory
    {
        get
        {
            return _shoesInventory;
        }

        set
        {
            _shoesInventory = value;
        }
    }

    public InventoryItem NecklaceInventory
    {
        get
        {
            return _necklaceInventory;
        }

        set
        {
            _necklaceInventory = value;
        }
    }

    public InventoryItem BraceletInventory
    {
        get
        {
            return _braceletInventory;
        }

        set
        {
            _braceletInventory = value;
        }
    }

    public InventoryItem RingInventory
    {
        get
        {
            return _ringInventory;
        }

        set
        {
            _ringInventory = value;
        }
    }

    public InventoryItem WingInventory
    {
        get
        {
            return _wingInventory;
        }

        set
        {
            _wingInventory = value;
        }
    }

    //public int HelmID
    //{
    //    get
    //    {
    //        return _helmID;
    //    }

    //    set
    //    {
    //        _helmID = value;
    //    }
    //}

    //public int WeaponID
    //{
    //    get
    //    {
    //        return _weaponID;
    //    }

    //    set
    //    {
    //        _weaponID = value;
    //    }
    //}

    //public int ShoesID
    //{
    //    get
    //    {
    //        return _shoesID;
    //    }

    //    set
    //    {
    //        _shoesID = value;
    //    }
    //}

    //public int NecklaceID
    //{
    //    get
    //    {
    //        return _necklaceID;
    //    }

    //    set
    //    {
    //        _necklaceID = value;
    //    }
    //}

    //public int BraceletID
    //{
    //    get
    //    {
    //        return _braceletID;
    //    }

    //    set
    //    {
    //        _braceletID = value;
    //    }
    //}

    //public int RingID
    //{
    //    get
    //    {
    //        return _ringID;
    //    }

    //    set
    //    {
    //        _ringID = value;
    //    }
    //}

    //public int WingID
    //{
    //    get
    //    {
    //        return _wingID;
    //    }

    //    set
    //    {
    //        _wingID = value;
    //    }
    //}

    //public int CloshID
    //{
    //    get
    //    {
    //        return _closhID;
    //    }

    //    set
    //    {
    //        _closhID = value;
    //    }
    //}
    #endregion

    #region unity event
    private PlayerInfo() { }
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (this.Energy < 100)
        {
            energyTime += Time.deltaTime;
            if(energyTime > 60)
            {
                Energy += 1;
                energyTime -= 60;
                OnPlayerInfoChanged(InfoType.Energy);
            }
        }
        else
        {
            this.energyTime = 0;
        }

        if (this.Toughen < 50)
        {
            toughenTime += Time.deltaTime;
            if (toughenTime > 60)
            {
                Toughen += 1;
                toughenTime -= 60;
                OnPlayerInfoChanged(InfoType.Toughen);
            }
        }
        else
        {
            this.toughenTime = 0;
        }
    }
    #endregion

    /// <summary>修改名字</summary>
    public void ChangeName(string name)
    {
        this.Name = name;
        OnPlayerInfoChanged(InfoType.Name);
    }
    /// <summary>穿上装备</summary>
    public void DressOn(InventoryItem it)
    {
        it.Isdressed = true;
        //首先检测有没有穿上相同类型的装备
        bool isDressed = false;
        InventoryItem inventoryItemDressed = null;
        switch (it.Inventory.EquipType)
        {
            case EquipType.Helm:
                if (HelmInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = HelmInventory;
                }
                    HelmInventory = it;
                break;
            case EquipType.Cloth:
                if (CloshInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = CloshInventory;
                }
                    CloshInventory = it; 
                break;
            case EquipType.Weapon:
                if (WeaponInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = WeaponInventory;
                }
                    WeaponInventory = it;
                break;
            case EquipType.Shoes:
                if (ShoesInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = ShoesInventory;
                }
                    ShoesInventory = it;
                break;
            case EquipType.Necklace:
                if (NecklaceInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = NecklaceInventory;
                }
                    NecklaceInventory = it;
                break;
            case EquipType.Bracelet:
                if (BraceletInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = BraceletInventory;
                }
                    BraceletInventory = it;
                break;
            case EquipType.Ring:
                if (RingInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = RingInventory;
                }
                    RingInventory = it;
                break;
            case EquipType.Wing:
                if (WingInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = WingInventory;
                }
                    WingInventory = it;
                break;
            default:
                break;
        }
        //有
        if (isDressed)
        {
            inventoryItemDressed.Isdressed = false;
            KnapsackInventoryUI._instance.AddInventoryItem(inventoryItemDressed);
        }
        OnPlayerInfoChanged(InfoType.Equip);
        //把已经存在的脱掉 放入背包
        //没有
        //直接穿上
    }
    /// <summary>卸下装备</summary>
    public void DressOff(InventoryItem it)
    {
        switch (it.Inventory.EquipType)
        {
            case EquipType.Helm:
                if (HelmInventory != null)
                {
                    HelmInventory = null;
                }
                break;
            case EquipType.Cloth:
                if (CloshInventory != null)
                {
                    CloshInventory = null;
                }
                break;
            case EquipType.Weapon:
                if (WeaponInventory != null)
                {
                    WeaponInventory = null;
                }
                break;
            case EquipType.Shoes:
                if (ShoesInventory != null)
                {
                    ShoesInventory = null;
                }
                break;
            case EquipType.Necklace:
                if (NecklaceInventory != null)
                {
                    NecklaceInventory = null;
                }
                break;
            case EquipType.Bracelet:
                if (BraceletInventory != null)
                {
                    BraceletInventory = null;
                }
                break;
            case EquipType.Ring:
                if (RingInventory != null)
                {
                    RingInventory = null;
                }
                break;
            case EquipType.Wing:
                if (WingInventory != null)
                {
                    WingInventory = null;
                }
                break;
            default:
                break;
        }
        it.Isdressed = false;
        KnapsackInventoryUI._instance.AddInventoryItem(it);
        OnPlayerInfoChanged(InfoType.Equip);
    }
    /// <summary>取得需要个数的金币数</summary>
    public bool GetCoin(int count)
    {
        if (Coin > count)
        {
            Coin -= count;
            OnPlayerInfoChanged(InfoType.Coin);
            return true;
        }
        return false;
    }
    /// <summary> 使用物品</summary>
    public void InventoryUse(InventoryItem it,int count)
    {
        //使用效果

        //处理物品使用后是否还存在
        it.Count -= count;
        if (it.Count<=0)
        {
            InventoryManager._instance.inventoryItemList.Remove(it);
        }
    }
    /// <summary>得到战斗力</summary>
    public int GetOverallPower()
    {
        float power = this.Power;
        if (HelmInventory!=null)
        {
            power += HelmInventory.Inventory.Power * (1 + (HelmInventory.Level - 1) / 10f);
        }
        if (CloshInventory != null)
        {
            power += CloshInventory.Inventory.Power * (1 + (CloshInventory.Level - 1) / 10f);
        }
        if (ShoesInventory != null)
        {
            power += ShoesInventory.Inventory.Power * (1 + (ShoesInventory.Level - 1) / 10f);
        }
        if (WeaponInventory != null)
        {
            power += WeaponInventory.Inventory.Power * (1 + (WeaponInventory.Level - 1) / 10f);
        }
        if (NecklaceInventory != null)
        {
            power += NecklaceInventory.Inventory.Power * (1 + (NecklaceInventory.Level - 1) / 10f);
        }
        if (BraceletInventory != null)
        {
            power += BraceletInventory.Inventory.Power * (1 + (BraceletInventory.Level - 1) / 10f);
        }
        if (RingInventory != null)
        {
            power += RingInventory.Inventory.Power * (1 + (RingInventory.Level - 1) / 10f);
        }
        if (WingInventory != null)
        {
            power += WingInventory.Inventory.Power * (1 + (WingInventory.Level - 1) / 10f);
        }

        return (int)power;
    }
    /// <summary>增加金币数</summary>
    public void AddCoin(int count)
    {
        this.Coin += count;
        OnPlayerInfoChanged(InfoType.Coin);
    }

    void Init()
    {
        this.Coin = 9999;
        this.Diamond = 999;
        this.Energy = 78;
        this.Exp = 123;
        this.HeadPortrait = "头像底板男性";
        this.Level = 12;
        this.Name = "雨夜带刀不带伞";
        this.Power = 4546;
        this.Toughen = 43;

        //this.BraceletID = 1001;
        //this.WingID = 1002;
        //this.RingID = 1003;
        //this.CloshID = 1004;
        //this.HelmID = 1005;
        //this.WeaponID = 1006;
        //this.NecklaceID = 1007;
        //this.ShoesID = 1008;

        InitHpDamagePower();

        OnPlayerInfoChanged(InfoType.All);
    }

    void InitHpDamagePower()
    {
        this.Hp = this.Level * 100;
        this.Damage = this.Level * 50;
        this.Power = this.Hp + this.Damage;
        //PutOnEquip(BraceletID);
        //PutOnEquip(WingID);
        //PutOnEquip(RingID);
        //PutOnEquip(CloshID);
        //PutOnEquip(HelmID);
        //PutOnEquip(WeaponID);
        //PutOnEquip(NecklaceID);
        //PutOnEquip(ShoesID);
    }

    //void PutOnEquip(int id)
    //{
    //    if (id == 0) return;
    //    Inventory inventory = null;

    //    InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);
    //    this.Hp += inventory.Hp;
    //    //print(Hp);
    //    this.Damage += inventory.Damage;
    //    this.Power += inventory.Power;
    //}
    //void PutOffEquip(int id)
    //{
    //    if (id == 0) return;
    //    Inventory inventory = null;
    //    InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);
    //    this.Hp -= inventory.Hp;
    //    this.Damage -= inventory.Damage;
    //    this.Power -= inventory.Power;
    //}
    
}
