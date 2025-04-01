using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfIdleState : WolfBaseState
{
    public WolfIdleState(WolfController WolfController, WolfData WolfData, string animationName) : base(WolfController, WolfData, animationName)
    {
    }

    public override void OnExecute()
    {
        base.OnExecute();
        if(WolfController.Target!=null){
            WolfController.SetMovementToTarget();
            if(WolfController.IsAttack){
                WolfController.ManagerWolfState.ChangeState(WolfController.WolfAttackState);
            }
            
        }
    }
}
