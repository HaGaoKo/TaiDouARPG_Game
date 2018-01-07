using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

    public static TaskManager _instance;

    public TextAsset taskinfoText;

    ArrayList taskList = new ArrayList();
    Task currentTask;   //保存当前的任务
    PlayerAutoMove playerAutoMove;
    PlayerAutoMove PlayerAutoMove
    {
        get
        {
            if (playerAutoMove == null)
            {
                playerAutoMove = GameObject.FindWithTag("Player").GetComponent<PlayerAutoMove>();
            }
            return playerAutoMove;
        }
    }
    private void Awake()
    {
        _instance = this;
        InitTask();
    }

    /// <summary>初始化任务信息</summary>
    void InitTask()
    {
        string[] taskInfoArray = taskinfoText.ToString().Split('\n');
        foreach (string str in taskInfoArray)
        {
            string[] proArray = str.Split('|');
            Task task = new Task
            {
                Id = int.Parse(proArray[0]),
            };
            switch (proArray[1])
            {
                case "Main":
                    task.TaskType = TaskType.Main;
                    break;
                case "Reward":
                    task.TaskType = TaskType.Reward;
                    break;
                case "Daily":
                    task.TaskType = TaskType.Daily;
                    break;
                default:
                    break;
            }
            task.Name = proArray[2];
            task.Icon = proArray[3];
            task.Des = proArray[4];
            task.Coin = int.Parse(proArray[5]);
            task.Diamond = int.Parse(proArray[6]);
            task.TalkNPC = proArray[7];
            task.IdNPC = int.Parse(proArray[8]);
            task.IdTranscript = int.Parse(proArray[9]);
            taskList.Add(task);
        }
    }

    /// <summary>返回任务列表信息</summary>
    public ArrayList GetTaskList()
    {
        return taskList;
    }
    /// <summary>执行某个任务</summary>
    public void OnExcuteTask(Task task)
    {
        currentTask = task;
        if (task.TaskProgress == TaskProgress.NoStart)
        {//导航到npc处接受任务
            PlayerAutoMove.SetDestination(NPCManager._instance.GetNpcById(task.IdNPC).transform.position);
        }
        else if(task.TaskProgress == TaskProgress.Accept)
        {
            PlayerAutoMove.SetDestination(NPCManager._instance.tranScript.position);
        }
    }

    public void OnAcceptTask()
    {
        currentTask.TaskProgress = TaskProgress.Accept;
        // 寻路到副本入口
        PlayerAutoMove.SetDestination(NPCManager._instance.tranScript.position);
    }

    public void OnArriveDestination()
    {
        //到达npc位置
        if (currentTask.TaskProgress == TaskProgress.NoStart)
        {
            NPCDialogUI._instance.Show(currentTask.TalkNPC);
        }
        //到达副本入口
    }
}
