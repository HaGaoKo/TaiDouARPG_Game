using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManage : MonoBehaviour {

    public static MessageManage _instance;
    UILabel label;
    TweenAlpha tween;
    //bool isSetActive = true;

    private void Awake()
    {
        _instance = this;
        label = transform.Find("Label").GetComponent<UILabel>();
        tween = this.GetComponent<TweenAlpha>();
        gameObject.SetActive(false);
        //EventDelegate.Add(tween.onFinished, OnTweenFinished);
    }
    /// <summary>提示信息显示方法 </summary>
    /// <param 提示信息="message"> </param>
    /// <param 动画时长="time"></param>
    public void ShowMessage(string message,float time)
    {
        gameObject.SetActive(true);
        StartCoroutine(Show(message, time));
    }

    IEnumerator Show(string message, float time=1)
    {
        //isSetActive = true;
        tween.PlayForward();
        label.text = message;
        yield return new WaitForSeconds(time);
        //isSetActive = false;
        tween.PlayReverse();
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
    //动画播放完回掉
    //void OnTweenFinished()
    //{
    //    if (!isSetActive)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
