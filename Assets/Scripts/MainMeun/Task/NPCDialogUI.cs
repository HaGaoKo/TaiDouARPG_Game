using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogUI : MonoBehaviour {

    public static NPCDialogUI _instance;

    TweenScale tween;
    UILabel npcTalkLabel;
    UIButton acceptBtn;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        tween = GetComponent<TweenScale>();
        npcTalkLabel = transform.Find("Label").GetComponent<UILabel>();
        acceptBtn = transform.Find("AcceptButton").GetComponent<UIButton>();
        EventDelegate.Add(acceptBtn.onClick, OnAcceptClick);
    }

    void OnAcceptClick()
    {
        //通知任务管理器 已经接受
        TaskManager._instance.OnAcceptTask();
        Hide();
    }

    public void Show(string npcTalk)
    {
        npcTalkLabel.text = npcTalk;
        tween.PlayForward();
    }
    public void Hide()
    {
        tween.PlayReverse();
    }
}
