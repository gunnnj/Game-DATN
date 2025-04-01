using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackState : WolfBaseState
{
    public WolfAttackState(WolfController WolfController, WolfData WolfData, string animationName) : base(WolfController, WolfData, animationName)
    {
    }
    public override void OnEnter()
    {
        base.OnEnter();
        WolfController.Animatior.SetBool("IsAttack", true);
        WolfController.WolfMovement.SetDirection(Vector3.zero);
    }
    
    public override void OnExecute()
    {
        base.OnExecute();
        if(!WolfController.IsAttack){
            WolfController.ManagerWolfState.ChangeState(WolfController.WolfIdleState);
        }
        if(WolfController.LowHP() && WolfController.IsShieldOn()){    
            WolfController.ManagerWolfState.ChangeState(WolfController.WolfBlockState);
        }
    }
    public override void OnExit()
    {
        base.OnExit();
        WolfController.Animatior.SetBool("IsAttack", false);
    }
}
