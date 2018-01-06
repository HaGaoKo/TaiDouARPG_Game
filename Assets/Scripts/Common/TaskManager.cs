using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

    public static TaskManager _instance;

    public TextAsset taskinfoText;
    ArrayList taskList = new ArrayList();

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
}
