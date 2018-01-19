using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTranscript : MonoBehaviour {

    public int id;
    public int needLevel;
    public string sceneName;
    public string des = "这里是一个副本描述，请补充完善...";

	public void OnClick()
    {
        transform.parent.SendMessage("OnBtnTranscriptClick", this);
    }
}
