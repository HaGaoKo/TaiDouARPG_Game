using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public static PlayerStatus _instance;

    #region 控件
    UISprite headSprite;
    UILabel levelLabel;
    UILabel nameLabel;
    UILabel powerLabel;
    UISlider expSlider;
    UILabel expLabel;
    UIButton changeNameBtn;
    UIButton closeBtn;
    UILabel diamondLabel;
    UILabel coinLabel;
    UILabel energyNumLabel;
    UILabel energyPartTimeLabel;
    UILabel energyAllTimeLabel;
    UILabel toughenNumLabel;
    UILabel toughenPartTimeLabel;
    UILabel toughenAllTimeLabel;

    TweenPosition tween;

    GameObject changeNameGo;
    UIInput nameInpue;
    UIButton sureButton;
    UIButton cancelButton;
    #endregion
    private void Awake()
    {
        _instance = this;
        headSprite = transform.Find("HeadSprite").GetComponent<UISprite>();
        levelLabel = transform.Find("LevelLabel").GetComponent<UILabel>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        powerLabel = transform.Find("PowerLabel").GetComponent<UILabel>();
        expSlider = transform.Find("ExpProgressBar").GetComponent<UISlider>();
        expLabel  = transform.Find("ExpProgressBar/Label").GetComponent<UILabel>();
        changeNameBtn = transform.Find("changeName").GetComponent<UIButton>();
        closeBtn = transform.Find("btn_close").GetComponent<UIButton>();
        diamondLabel = transform.Find("DiamondLabel/Label").GetComponent<UILabel>();
        coinLabel = transform.Find("CoinLabel/Label").GetComponent<UILabel>();
        energyNumLabel = transform.Find("EnergyLabel/NumLabel").GetComponent<UILabel>();
        energyPartTimeLabel = transform.Find("EnergyLabel/RestorePartTime").GetComponent<UILabel>();
        energyAllTimeLabel = transform.Find("EnergyLabel/RestoreAllTime").GetComponent<UILabel>();
        toughenNumLabel = transform.Find("ToughenLabel/NumLabel").GetComponent<UILabel>();
        toughenPartTimeLabel = transform.Find("ToughenLabel/RestorePartTime").GetComponent<UILabel>();
        toughenAllTimeLabel = transform.Find("ToughenLabel/RestoreAllTime").GetComponent<UILabel>();
        tween = GetComponent<TweenPosition>();
        changeNameGo = transform.Find("changeNameBg").gameObject;
        changeNameGo.SetActive(false);
        nameInpue = changeNameGo.transform.Find("nameInput").GetComponent<UIInput>();
        sureButton = changeNameGo.transform.Find("btn_sure").GetComponent<UIButton>();
        cancelButton = changeNameGo.transform.Find("btn_cancel").GetComponent<UIButton>();
    }

    private void Start()
    {
        PlayerInfo._instance.OnPlayerInfoChanged += OnPlayerInfoChanged;
        EventDelegate.Add(closeBtn.onClick, CloseButtonClick);
        EventDelegate.Add(changeNameBtn.onClick, OnButtonChangeNameClick);
        EventDelegate.Add(sureButton.onClick, OnButtonSureClick);
        EventDelegate.Add(cancelButton.onClick, OnButtonCancelClick);
    }

    private void Update()
    {
        UpdateEnergyAndToughenShow();
    }

    private void OnDestroy()
    {
        PlayerInfo._instance.OnPlayerInfoChanged -= OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(InfoType type)
    {
        UpdateShow();
    }

    void UpdateShow()
    {
        PlayerInfo info = PlayerInfo._instance;
        headSprite.spriteName = info.HeadPortrait;
        levelLabel.text = info.Level.ToString();
        nameLabel.text = info.Name;
        powerLabel.text = info.Power.ToString();
        int requireExp = GameController.GetRequilerExpByLevel(info.Level+1);
        expSlider.value = (float)info.Exp / requireExp;
        expLabel.text = info.Exp + "/" + requireExp;
        diamondLabel.text = info.Diamond.ToString();
        coinLabel.text = info.Coin.ToString();

        UpdateEnergyAndToughenShow();
    }

    void UpdateEnergyAndToughenShow()
    {
        PlayerInfo info = PlayerInfo._instance;
        energyNumLabel.text = info.Energy + "/100";
        if (info.Energy >= 100)
        {
            energyPartTimeLabel.text = "00:00:00";
            energyAllTimeLabel.text = "00:00:00";
        }
        else
        {
            int remainTime = 60 - (int)info.energyTime;
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            energyPartTimeLabel.text = "00:00:" + str;

            int minues = 99 - info.Energy;
            int hours = minues / 60;
            energyAllTimeLabel.text = string.Format("{0:d2}:{1:d2}:{2:d2}", hours, minues, int.Parse(str));
        }

        toughenNumLabel.text = info.Toughen + "/50";
        if (info.Toughen >= 50)
        {
            toughenPartTimeLabel.text = "00:00:00";
            toughenAllTimeLabel.text = "00:00:00";
        }
        else
        {
            int remainTime = 60 - (int)info.toughenTime;
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            toughenPartTimeLabel.text = "00:00:" + str;

            int minues = 49 - info.Toughen;
            int hours = minues / 60;
            toughenAllTimeLabel.text = string.Format("{0:d2}:{1:d2}:{2:d2}", hours, minues, int.Parse(str));
        }
    }

    public void Show()
    {
        tween.PlayForward();
    }

    void CloseButtonClick()
    {
        tween.PlayReverse();
    }

    void OnButtonChangeNameClick()
    {
        changeNameGo.SetActive(true);
        changeNameGo.GetComponent<TweenScale>().PlayForward();
    }
    void OnButtonSureClick()
    {
        //校验名字是否重复
        PlayerInfo._instance.ChangeName(nameInpue.value);
        OnButtonCancelClick();
    }
    void OnButtonCancelClick()
    {
        changeNameGo.GetComponent<TweenScale>().PlayReverse();
        StartCoroutine(Hide(changeNameGo));
        changeNameGo.transform.Find("nameInput/Label").GetComponent<UILabel>().text = "请输入新名字...";
    }
    IEnumerator Hide(GameObject go,float t= 0.5f)
    {
        yield return new WaitForSeconds(t);
        go.SetActive(false);
    }
}
