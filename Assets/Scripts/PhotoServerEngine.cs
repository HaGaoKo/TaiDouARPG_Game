/****************************************************
**************Create By HaGaoKo**********************
****************************************************/
using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoServerEngine : MonoBehaviour,IPhotonPeerListener {

    public Button btn;
    public PhotonPeer peer;
    public InputField inputField;
    public Text text;
    bool isConnected = false;
    void Start()
    {
        peer = new PhotonPeer(this, ConnectionProtocol.Tcp);
        peer.Connect("127.0.0.1:4530", "ChatServer");
    }

    private void Update()
    {
        peer.Service();
    }

    public void OnButtonClick()
    {
        if (isConnected)
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>();
            dict.Add(1, inputField.text);
            inputField.text = "";
            //dict.Add(2, "password");
            peer.OpCustom(1, dict, true);
            //Debug.Log(131112132);
        }
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log(level + ":" + message);
    }

    public void OnEvent(EventData eventData)
    {
        
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        Dictionary<byte, object> dict = operationResponse.Parameters;
        object v = null;
        dict.TryGetValue(1, out v);
        text.text += v.ToString()+"\n";
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        switch (statusCode)
        {
            case StatusCode.Connect:
                isConnected = true;
                text.text += Network.player.ipAddress + "上线了...\n";
                //Debug.Log("连接成功");
                break;
        }
    }
}
