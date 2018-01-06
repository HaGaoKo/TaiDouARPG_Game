using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShow : MonoBehaviour {

    private void OnPress(bool isPress)//NGUI中点击方法
    {
        if (!isPress)
        {
            StartMenuController._instance.OnCharacterClick(transform.parent.gameObject);
        }
    }
}
