using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBaseState
{
    protected WolfController WolfController;
    protected WolfData WolfData;
    private string animationName;

    public WolfBaseState(WolfController WolfController, WolfData WolfData, string animationName)
    {
        this.WolfController = WolfController;
        this.WolfData = WolfData;
        this.animationName = animationName;
    }

    public virtual void OnEnter()
    {
        WolfController.Animatior.SetBool(animationName, true);
         
    }
    public virtual void OnExecute(){}

    public virtual void OnExit()
    {
        
        WolfController.Animatior.SetBool(animationName, false);
    }

}
