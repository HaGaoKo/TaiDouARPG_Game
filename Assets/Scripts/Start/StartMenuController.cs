/****************************************************
**************Create By HaGaoKo**********************
****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartMenuController : MonoBehaviour
{
    public static StartMenuController _instance;//单例

    public TweenAlpha startpanelTween;      //开始界面
    public TweenAlpha loginpanelTween;      //登陆
    public TweenAlpha registerpanelTween;   //注册
    public TweenScale serverPanelTween;     //选服
    public TweenPosition startpanelTweenPos;//开始界面动画
    public TweenPosition characterselectTween;//预览选人界面动画
    public TweenPosition charactershowTween;  //选择角色界面动画

    public UIInput usernameInputLogin;      
    public UIInput passwordInputLogin;

    public UILabel usernameLabelStart;
    public UILabel servernameLabelStart;

    public static string username;
    public static string password;
    public static ServerProperty sp;

    public UIInput usernameInputRegister;
    public UIInput passwordInputRegister;
    public UIInput repasswordInputRegister;

    public UIGrid serverListGrid;
    public GameObject serverItemRed;
    public GameObject serverItemGreen;

    private bool haveInitServerList = false;

    public GameObject serverSelectGo;

    public GameObject[] CharacterArray;
    public GameObject[] CharacterSelectArray;

    private GameObject characterSelected;   //当前选择的角色

    public UIInput characternameInpue;   //玩家输入的角色的name

    public Transform characterSelectParent; //实例化prefab的父物体的位置
    public UILabel nameLabelCharacterselect;  //角色选择界面name
    public UILabel levelLabelCharacterselect;//角色选择界面lv

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        InitServerList();//初始化服务器列表  
    }

    public void OnUsernameClick()
    {
        startpanelTween.PlayForward();
        StartCoroutine(HidePanel(startpanelTween.gameObject, loginpanelTween.gameObject));
        loginpanelTween.PlayForward();
    }
    public void OnServerClick()
    {
        //选择服务器
        startpanelTween.PlayForward();
        StartCoroutine(HidePanel(startpanelTween.gameObject, serverPanelTween.gameObject));
        serverPanelTween.PlayForward();

        //初始化服务器列表
        //InitServerList();
    }


    public void OnEnterClick()
    {
        //连接服务器 验证用户名和服务区
        //TODO

        //进入角色选择界面
        startpanelTweenPos.PlayForward();
        StartCoroutine(HidePanel(startpanelTweenPos.gameObject, null,1f));
       
        characterselectTween.gameObject.SetActive(true);
        characterselectTween.PlayForward();
    }

    IEnumerator HidePanel(GameObject go, GameObject go2=null, float t = 0.3f,float t2 = 0.2f)
    {
        yield return new WaitForSeconds(t);
        go.SetActive(false);
        yield return new WaitForSeconds(t2);
        if (go2 != null)
        {
            go2.SetActive(true);
        }
    }

    public void OnLoginClick()
    {
        //得到用户名和密码存储起来
        username = usernameInputLogin.value;
        password = passwordInputLogin.value;
        //返回开始界面
        loginpanelTween.PlayReverse();
        StartCoroutine(HidePanel(loginpanelTween.gameObject, startpanelTween.gameObject));
        //startpanelTween.gameObject.SetActive(true);
        startpanelTween.PlayForward();

        usernameLabelStart.text = username;
    }

    public void OnRegisterShowClick()
    {
        //影藏当前面板 显示注册面版
        loginpanelTween.PlayReverse();
        StartCoroutine(HidePanel(loginpanelTween.gameObject, registerpanelTween.gameObject));
        //registerpanelTween.gameObject.SetActive(true);
        registerpanelTween.PlayForward();

    }

    public void OnLoginCloseClick()
    {
        loginpanelTween.PlayReverse();
        StartCoroutine(HidePanel(loginpanelTween.gameObject, startpanelTween.gameObject));
        //startpanelTween.gameObject.SetActive(true);
        startpanelTween.PlayForward();
    }

    public void OnCancelClick()
    {
        registerpanelTween.PlayReverse();
        StartCoroutine(HidePanel(registerpanelTween.gameObject, loginpanelTween.gameObject));
        //loginpanelTween.gameObject.SetActive(true);
        loginpanelTween.PlayForward();
    }

    public void OnRegisterCloseClick()
    {
        OnCancelClick();
    }
    public void OnRegisterAndLoginClick()
    {
        //本地校验，连接服务器进行验证

        //链接失败

        //连接成功  保存用户名和密码 返回开始界面
        username = usernameInputRegister.value;
        password = passwordInputRegister.value;
        registerpanelTween.PlayReverse();
        StartCoroutine(HidePanel(registerpanelTween.gameObject, startpanelTween.gameObject));
        //startpanelTween.gameObject.SetActive(true);
        startpanelTween.PlayForward();
        usernameLabelStart.text = username;
    }

    public void InitServerList()
    {
        if (haveInitServerList) return;

        //连接服务器 取得游戏服务器列表信息


        //根据上面的信息 添加服务器列表
        for (int i = 0; i < 20; i++)
        {
            //public string ip = "127.0.0.1:9090";
            //public new string name = "1区 马达加斯加";
            //public int count = 100;
            string ip = "";
            string name = (i + 1) + "区 马达加斯加";
            int count = Random.Range(0, 101);
            GameObject go = null;
            if (count > 50)
            {//火爆
                go = NGUITools.AddChild(serverListGrid.gameObject, serverItemRed);
            }
            else
            {
                go = NGUITools.AddChild(serverListGrid.gameObject, serverItemGreen);
            }
            ServerProperty sp = go.GetComponent<ServerProperty>();
            sp.ip = ip;
            sp.name = name;
            sp.count = count;

            go.transform.parent = serverListGrid.transform;
            //serverListGrid.AddChild(go.transform);
        }

        haveInitServerList = true;
    }

    public void OnServerSelect(GameObject serverGo)
    {
        sp = serverGo.GetComponent<ServerProperty>();

        serverSelectGo.GetComponent<UISprite>().spriteName = serverGo.GetComponent<UISprite>().spriteName;
        serverSelectGo.transform.Find("Label").GetComponent<UILabel>().text = sp.name;
        //print(sp.name);
    }

    public void OnServerPanelClose()
    {
        serverPanelTween.PlayReverse();
        StartCoroutine(HidePanel(serverPanelTween.gameObject, startpanelTween.gameObject));
        startpanelTween.PlayForward();
        servernameLabelStart.text = sp.name;
    }

    public void OnCharacterClick(GameObject go)
    {
        if (go != characterSelected)
        {
            go.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.5f);
            if (characterSelected != null)
            {
                characterSelected.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
            }
            characterSelected = go;
        }
    }
    //点击更换角色按钮
    public void OnButtonChangecharacterClick()
    {
        characterselectTween.PlayReverse();
        StartCoroutine(HidePanel(characterselectTween.gameObject, null, 1));
        charactershowTween.gameObject.SetActive(true);
        charactershowTween.PlayForward();

    }

    public void OnCharactershowButtonSureClick()
    {
        //判断姓名输入是否正确
        //判断是否选择角色

        int index = -1;
        for (int i = 0; i < CharacterArray.Length; i++)
        {
            if (characterSelected==CharacterArray[i])
            {
                index = i;
                break;
            }
        }
        if (index==-1)
        {
            return;
        }
        //销毁现有的角色
        if (characterSelectParent.childCount > 0)
        {
            Destroy(characterSelectParent.GetComponentInChildren<Animation>().gameObject);
        }
        //创建新的角色
        GameObject go = Instantiate(CharacterSelectArray[index],Vector3.zero,Quaternion.identity);
        go.transform.parent = characterSelectParent;
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale = Vector3.one;
        //更新角色的名字和等级
        nameLabelCharacterselect.text = characternameInpue.value;
        levelLabelCharacterselect.text = "Lv.1";
        OnCharactershowButtonBackClick();
    }
    //角色选择界面返回按钮
    public void OnCharactershowButtonBackClick()
    {
        charactershowTween.PlayReverse();
        StartCoroutine(HidePanel(charactershowTween.gameObject, null, 1));
        characterselectTween.gameObject.SetActive(true);
        characterselectTween.PlayForward();
    }
}



