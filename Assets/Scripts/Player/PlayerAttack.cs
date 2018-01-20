using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    Dictionary<string, PlayerEffect> effectDict = new Dictionary<string, PlayerEffect>();

    private void Start()
    {
        PlayerEffect[] pe = GetComponentsInChildren<PlayerEffect>();
        foreach (PlayerEffect  item in pe)
        {
            effectDict.Add(item.gameObject.name, item);
        }
    }

    //
    //0 normal skill1 skill2 skill3
    //1 effect name
    //2 sound name
    //3 move forward
    //4 jump height
    void Attack(string args)
    {
        string[] str = args.Split(',');
        string effectName = str[1];
        ShowPlayerEffect(effectName);
    }

    void ShowPlayerEffect(string effectName)
    {
        PlayerEffect pe;
        if(effectDict.TryGetValue(effectName, out pe))
        {
            pe.Show();
        }
    }
}
