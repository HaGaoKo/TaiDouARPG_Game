using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour {

    public PosType posType;
    public float coldTime = 4;
    float coldTimer = 0;
    UISprite mask;
    UIButtonScale btn;

    PlayerAnimation playerAnimation;

    private void Awake()
    {
        btn = GetComponent<UIButtonScale>();
        if (transform.Find("mask"))
        {
            mask = transform.Find("mask").GetComponent<UISprite>();
        }
    }

    private void Start()
    {
        playerAnimation = TranscriptManager._instance.player.GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (mask == null) return;

        if (coldTimer > 0)
        {
            coldTimer -= Time.deltaTime;
            mask.fillAmount = coldTimer / coldTime;
            if (coldTimer<=0)
            {
                ButtonAble(true);
            }
        }
        else
        {
            mask.fillAmount = 0;
        }
    }

    void OnPress(bool isPress)
    {
        playerAnimation.OnAttackButtonClick(isPress, posType);
        if (isPress && mask!=null)
        {
            coldTimer = coldTime;
            ButtonAble(false);
        }
    }

    void ButtonAble(bool isTrue)
    {
        GetComponent<Collider>().enabled = isTrue;
        btn.enabled = isTrue;
    }
}
