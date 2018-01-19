using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscriptMapUI : MonoBehaviour {

    public static TranscriptMapUI _instance;
    TranscriptMapDialog transcriptMapDialog;
    TweenPosition tween;

    private void Awake()
    {
        _instance = this;
        tween = GetComponent<TweenPosition>();
        transcriptMapDialog = transform.Find("TranscriptMapDialog").GetComponent<TranscriptMapDialog>();
    }

    void OnBtnTranscriptClick(BtnTranscript btnTranscript)
    {
        PlayerInfo info = PlayerInfo._instance;

        if (info.Level >= btnTranscript.needLevel)
        {
            transcriptMapDialog.ShowDialog(btnTranscript);
        }
        else
        {
            transcriptMapDialog.ShowWarn();
        }
    }

    public void Show()
    {
        tween.PlayForward();
    }
    void Hide()
    {
        tween.PlayReverse();
    }

    void OnEnter()
    {

    }
}
