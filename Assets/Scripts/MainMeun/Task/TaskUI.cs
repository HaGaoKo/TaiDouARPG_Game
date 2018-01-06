using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUI : MonoBehaviour {

    public static TaskUI _instance;

    UIGrid taskListGrid;
    TweenPosition tween;
    UIButton closeBtn;

    public GameObject taskItemPrefab;

    private void Awake()
    {
        _instance = this;
        taskListGrid = transform.Find("Scroll View/Grid").GetComponent<UIGrid>();
        tween = GetComponent<TweenPosition>();
        closeBtn = transform.Find("Btn_close").GetComponent<UIButton>();
    }
    private void Start()
    {
        InitTaskList();
        EventDelegate.Add(closeBtn.onClick, Close);
    }

    /// <summary>初始化任务列表信息</summary>
    void InitTaskList()
    {
        ArrayList taskList = TaskManager._instance.GetTaskList();

        foreach(Task task in taskList)
        {
            GameObject go = NGUITools.AddChild(taskListGrid.gameObject, taskItemPrefab);
            go.transform.parent = taskListGrid.transform;
            //taskListGrid.AddChild(go.transform);
            TaskItemUI ti = go.GetComponent<TaskItemUI>();
            ti.SetTask(task);
        }
    }
    /// <summary>关闭窗口</summary>
    void Close()
    {
        Hide();
    }

    /// <summary>显示</summary>
    public void Show()
    {
        tween.PlayForward();
    }
    /// <summary>隐藏</summary>
    public void Hide()
    {
        tween.PlayReverse();
    }
}
