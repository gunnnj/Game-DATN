using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBlockState : WolfBaseState
{
    public WolfBlockState(WolfController WolfController, WolfData WolfData, string animationName) : base(WolfController, WolfData, animationName)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        WolfController.Animatior.SetBool("IsBlock",true);
        WolfController.TurnOnShield();
    }

    public override void OnExecute()
    {
        base.OnExecute();
        if(!WolfController.IsShieldOn()){
            WolfController.ManagerWolfState.ChangeState(WolfController.WolfIdleState);
        }
    }
    public override void OnExit()
    {
        base.OnExit();
        WolfController.Animatior.SetBool("IsBlock",false);
    }

}
