using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerProperty : MonoBehaviour
{
    public string ip = "127.0.0.1:9090";
    private string _name;
    public new string name
    {
        set
        {
            transform.Find("Label").GetComponent<UILabel>().text = value;
            _name = value;
        }
        get { return _name; }
    }

    public int count = 100;

    public void OnPress(bool isPress)
    {
        if (!isPress)
        {
            //选择了当前的服务器
            transform.root.SendMessage("OnServerSelect", this.gameObject);
        }
    }
}
