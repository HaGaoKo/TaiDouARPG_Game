using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    ///<summary>等级经验增长规则 <returns></returns>
    public static int GetRequilerExpByLevel(int lv)
    {// (lv-1)*(100+(100+10*(lv-2)))/2
        return (lv - 1) * (100 + (100 + 10 * (lv - 2))) / 2;
    }

}
