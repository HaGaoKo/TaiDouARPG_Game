
public enum TaskType
{
    /// <summary>主线任务 </summary>
    Main,
    /// <summary>赏金任务 </summary>
    Reward,
    /// <summary>日常任务 </summary>
    Daily
}
public enum TaskProgress
{
    /// <summary>未开始 </summary>
    NoStart,
    /// <summary>接受 </summary>
    Accept,
    /// <summary>完成 </summary>
    Complete,
    /// <summary>获取奖励 </summary>
    Reward
}

public class Task {
    int id;
    TaskType taskType;
    string name;
    string icon;
    string des;
    int coin;
    int diamond;
    string talkNPC;
    int idNPC;
    int idTranscript;
    TaskProgress taskProgress = TaskProgress.NoStart;

    #region
    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public TaskType TaskType
    {
        get
        {
            return taskType;
        }

        set
        {
            taskType = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    public string Des
    {
        get
        {
            return des;
        }

        set
        {
            des = value;
        }
    }

    public int Coin
    {
        get
        {
            return coin;
        }

        set
        {
            coin = value;
        }
    }

    public int Diamond
    {
        get
        {
            return diamond;
        }

        set
        {
            diamond = value;
        }
    }

    public string TalkNPC
    {
        get
        {
            return talkNPC;
        }

        set
        {
            talkNPC = value;
        }
    }

    public int IdNPC
    {
        get
        {
            return idNPC;
        }

        set
        {
            idNPC = value;
        }
    }

    public int IdTranscript
    {
        get
        {
            return idTranscript;
        }

        set
        {
            idTranscript = value;
        }
    }

    public TaskProgress TaskProgress
    {
        get
        {
            return taskProgress;
        }

        set
        {
            taskProgress = value;
        }
    }
    #endregion
}
