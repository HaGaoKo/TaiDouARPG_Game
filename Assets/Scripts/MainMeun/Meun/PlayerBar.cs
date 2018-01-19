using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBar : MonoBehaviour {

    UISprite headSprite;
    UILabel nameLabel;
    UILabel levelLabel;
    UILabel energyLabel;
    UILabel toughenLabel;
    UISlider energySlider;
    UISlider toughenSlider;
    //UIButton energyButton;
    //UIButton toughenButton;
    UIButton headButton;
    private void Awake()
    {
        headSprite = transform.Find("HeadSprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("LevelLabel").GetComponent<UILabel>();
        energySlider = transform.Find("EnergyProgressBar").GetComponent<UISlider>();
        energyLabel = energySlider.transform.Find("Label").GetComponent<UILabel>();
        toughenSlider = transform.Find("ToughenProgressBar").GetComponent<UISlider>();
        toughenLabel = toughenSlider.transform.Find("Label").GetComponent<UILabel>();
        //energyButton = transform.Find("EnergyPlusButton").GetComponent<UIButton>();
        //toughenButton = transform.Find("ToughenPlusButton").GetComponent<UIButton>();
        headButton = transform.Find("HeadButton").GetComponent<UIButton>();
    }

    private void Start()
    {
        PlayerInfo._instance.OnPlayerInfoChanged += OnPlayerInfoChanged;

        headButton.onClick.Add(new EventDelegate(this, "OnHeadButtonClick"));
        //UIEventListener.Get(headButton.gameObject).onClick = (x) => { };
        //UIEventListener.Get(headButton.gameObject).onClick = OnHeadButtonClick;

        ////EventDelegate.Add(headButton.onClick, OnHeadButtonClick);
    }

    private void OnDestroy()
    {
        PlayerInfo._instance.OnPlayerInfoChanged -= OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(InfoType type)
    {
        if(type== InfoType.Name||type==InfoType.Level||type== InfoType.HeadPortarit||type== InfoType.Energy||type== InfoType.Toughen||type== InfoType.All)
        {
            UpdateShow();
        }
    }

    void UpdateShow()
    {
        PlayerInfo info = PlayerInfo._instance;
        headSprite.spriteName = info.HeadPortrait;
        levelLabel.text = info.Level.ToString();
        nameLabel.text = info.Name.ToString();
        energySlider.value = info.Energy / 100f;
        energyLabel.text = info.Energy + "/100";
        toughenSlider.value = info.Toughen / 50f;
        toughenLabel.text = info.Toughen + "/50";
    }

    public void OnHeadButtonClick()
    {
        PlayerStatus._instance.Show();
    }
}
