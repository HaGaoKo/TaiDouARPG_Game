using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItemUI : MonoBehaviour {

    UISprite tasktyprSprite;
    UISprite iconSprite;
    UILabel nameLabel;
    UILabel desLabel;
    UISprite reward1Sprite;
    UILabel reward1Label;
    UISprite reward2Sprite;
    UILabel reward2Label;
    UIButton combatBtn;
    UIButton rewardBtn;

    private void Awake()
    {
        tasktyprSprite = transform.Find("").GetComponent<UISprite>();
        iconSprite = transform.Find("").GetComponent<UISprite>();
        nameLabel = transform.Find("").GetComponent<UILabel>();
        desLabel = transform.Find("").GetComponent<UILabel>();
        reward1Sprite = transform.Find("").GetComponent<UISprite>();
        reward1Label = transform.Find("").GetComponent<UILabel>();
        reward2Sprite = transform.Find("").GetComponent<UISprite>();
        reward2Label = transform.Find("").GetComponent<UILabel>();
        combatBtn = transform.Find("").GetComponent<UIButton>();
        rewardBtn = transform.Find("").GetComponent<UIButton>();
    }
}
