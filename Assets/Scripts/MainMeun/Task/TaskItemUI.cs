using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItemUI : MonoBehaviour {

    //Task task;

    UISprite tasktyprSprite;
    UISprite iconSprite;
    UILabel nameLabel;
    UILabel desLabel;
    UISprite reward1Sprite;
    UILabel reward1Label;
    UISprite reward2Sprite;
    UILabel reward2Label;
    UIButton combatBtn;
    UILabel combatLabel;
    UIButton rewardBtn;

    private void Awake()
    {
        tasktyprSprite = transform.Find("TaskType").GetComponent<UISprite>();
        iconSprite = transform.Find("IconBg/Sprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();
        reward1Sprite = transform.Find("Reward1Sprite").GetComponent<UISprite>();
        reward1Label = transform.Find("Reward1Label").GetComponent<UILabel>();
        reward2Sprite = transform.Find("Reward2Sprite").GetComponent<UISprite>();
        reward2Label = transform.Find("Reward2Label").GetComponent<UILabel>();
        combatBtn = transform.Find("CombatButton").GetComponent<UIButton>();
        combatLabel = combatBtn.GetComponentInChildren<UILabel>();
        rewardBtn = transform.Find("RewardButton").GetComponent<UIButton>();
    }

    public void SetTask(Task task)
    {
        //this.task = task;
        switch (task.TaskType)
        {
            case TaskType.Main:
                tasktyprSprite.spriteName = "pic_主线";
                break;
            case TaskType.Reward:
                tasktyprSprite.spriteName = "pic_奖赏";
                break;
            case TaskType.Daily:
                tasktyprSprite.spriteName = "pic_日常";
                break;
            default:
                break;
        }
        iconSprite.spriteName = task.Icon;
        nameLabel.text = task.Name;
        desLabel.text = task.Des;
        if (task.Coin>0 && task.Diamond > 0)
        {
            reward1Sprite.spriteName = "金币";
            reward1Label.text = "x" + task.Coin;
            reward2Sprite.spriteName = "钻石";
            reward2Label.text = "x" + task.Coin;
        }
        else if(task.Coin > 0)
        {
            reward1Sprite.spriteName = "金币";
            reward1Label.text = "x" + task.Coin;
            reward2Sprite.gameObject.SetActive(false);
            reward2Label.gameObject.SetActive(false);
        }
        else if (task.Diamond > 0)
        {
            reward1Sprite.gameObject.SetActive(false);
            reward1Label.gameObject.SetActive(false);
            reward2Sprite.spriteName = "钻石";
            reward2Label.text = "x" + task.Diamond;
        }
        switch (task.TaskProgress)
        {
            case TaskProgress.NoStart:
                rewardBtn.gameObject.SetActive(false);
                combatLabel.text = "下一步";
                break;
            case TaskProgress.Accept:
                rewardBtn.gameObject.SetActive(false);
                combatLabel.text = "战斗";
                break;
            case TaskProgress.Complete:
                rewardBtn.gameObject.SetActive(true);
                combatBtn.gameObject.SetActive(false);
                break;
            case TaskProgress.Reward:
                break;
            default:
                break;
        }
    }
}
