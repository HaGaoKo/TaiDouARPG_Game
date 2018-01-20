using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnAttackButtonClick(bool isPress, PosType posType)
    {
        if (posType == PosType.Basic)
        {
            if (isPress)
            {
                anim.SetTrigger("Attack");
            }
        }
        else
        {
            anim.SetBool("Skill" + (int)posType, isPress);
        }
    }
}
