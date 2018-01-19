using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscriptMapDialog : MonoBehaviour {

    UILabel deslabel;
    UILabel enengyTagLabel;
    UILabel energyLabel;
    UIButton closeBtn;
    UIButton enterBtn;
    TweenScale tween;

    private void Awake()
    {
        deslabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        enengyTagLabel = transform.Find("Bg/enengyTagLabel").GetComponent<UILabel>();
        energyLabel = transform.Find("Bg/EnergyLabel").GetComponent<UILabel>();
        closeBtn = transform.Find("Btn_close").GetComponent<UIButton>();
        enterBtn = transform.Find("BtnEnter").GetComponent<UIButton>();
        tween = GetComponent<TweenScale>();
    }
    private void Start()
    {
        EventDelegate.Add(enterBtn.onClick,OnEnter);
        EventDelegate.Add(closeBtn.onClick,OnClose);
    }

    void OnEnter()
    {
        transform.parent.SendMessage("OnEnter");
    }
    void OnClose()
    {
        Hide();
    }

    public void ShowWarn()
    {
        energyLabel.enabled = false;
        enengyTagLabel.enabled = false;
        enterBtn.SetState(UIButton.State.Disabled, true);
        enterBtn.GetComponent<Collider>().enabled = false;

        deslabel.text = "角色当前等级不足，无法进入地下城！";
        Show();
    }
    public void ShowDialog(BtnTranscript transcript)
    {
        energyLabel.enabled = true;
        enengyTagLabel.enabled = true;
        enterBtn.SetState(UIButton.State.Normal, true);
        enterBtn.GetComponent<Collider>().enabled = true;

        deslabel.text = transcript.des;
        energyLabel.text = "3";
        Show();
    }

    void Show()
    {
        tween.PlayForward();
    }
    void Hide()
    {
        tween.PlayReverse();
    }
}
