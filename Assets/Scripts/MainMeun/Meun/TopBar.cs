using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : MonoBehaviour {

    UILabel diamonLabel;
    UILabel coinLabel;
    //UIButton diamonButton;
    //UIButton coinButton;

    private void Awake()
    {
        diamonLabel = transform.Find("DiamondBg/Label").GetComponent<UILabel>();
        coinLabel = transform.Find("CoinBg/Label").GetComponent<UILabel>();
        //diamonButton = transform.Find("DiamondBg/Sprite").GetComponent<UIButton>();
        //coinButton = transform.Find("CoinBg/Sprite").GetComponent<UIButton>();
    }

    private void Start()
    {
        PlayerInfo._instance.OnPlayerInfoChanged += OnPlayerInfoChanged;
    }
    private void OnDestroy()
    {
        PlayerInfo._instance.OnPlayerInfoChanged -= OnPlayerInfoChanged;
    }
    void OnPlayerInfoChanged(InfoType type)
    {
        if(type== InfoType.All|| type == InfoType.Diamond || type == InfoType.Coin)
        {
            UpdateShow();
        }
    }

    void UpdateShow()
    {
        PlayerInfo info = PlayerInfo._instance;
        diamonLabel.text = info.Diamond.ToString();
        coinLabel.text = info.Coin.ToString();
    }
}
