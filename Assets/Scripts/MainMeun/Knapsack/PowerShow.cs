using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShow : MonoBehaviour {

    float startValue = 0;
    float endValue = 0;

    bool isStart = false;
    bool isUP = true;
    public int speed = 1000;

    UILabel numLabel;
    TweenAlpha tween;

    private void Awake()
    {
        numLabel = transform.Find("Label").GetComponent<UILabel>();
        tween = GetComponent<TweenAlpha>();
        gameObject.SetActive(false);
    }

    private void Start()
    {
        EventDelegate.Add(tween.onFinished, OnTweenFinished);
    }

    private void Update()
    {
        if (isStart)
        {
            if (isUP)
            {
                startValue += speed * Time.deltaTime;
                if (startValue >= endValue)
                {
                    isStart = false;
                    startValue = endValue;
                    tween.PlayReverse();
                }
            }
            else
            {
                startValue -= speed * Time.deltaTime;
                if (startValue <= endValue)
                {
                    isStart = false;
                    startValue = endValue;
                    tween.PlayReverse();
                }
            }
            numLabel.text = ((int)startValue).ToString();
        }
    }

    public void ShowPowerChange(float startValue,float endValue)
    {
        gameObject.SetActive(true);
        tween.PlayForward();
        this.startValue = startValue;
        this.endValue = endValue;
        if (endValue>startValue)
        {
            isUP = true;
        }
        else
        {
            isUP = false;
        }
        isStart = true;
    }

    void OnTweenFinished()
    {
        if (!isStart)
        {
            gameObject.SetActive(false);
        }
    }
}
