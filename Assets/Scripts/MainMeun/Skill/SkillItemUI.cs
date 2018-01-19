using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItemUI : MonoBehaviour {

    public PosType posType;
    public bool isSelect = false;
    Skill skill;
    UISprite sprite;
    UISprite Sprite
    {
        get
        {
            if (sprite==null)
            {
                sprite = GetComponent<UISprite>();
            }
            return sprite;
        }
    }
    UIButton button;
    UIButton Button
    {
        get
        {
            if (button==null)
            {
                button = GetComponent<UIButton>();
            }
            return button;
        }
    }

    private void Start()
    {
        UpdateShow();
        if (isSelect)//默认显示当前选择的技能 开始显示第一个
        {
            OnPress(true);
        }
    }

    void UpdateShow()
    {
        skill = SkillManager._instance.GetSkillByPosition(posType);
        Sprite.spriteName = skill.Icon;
        Button.normalSprite = skill.Icon;
    }

    void OnPress(bool isPress)
    {
        if (isPress)
        {
            transform.parent.parent.SendMessage("OnSkillClick", skill);
        }
    }
}
