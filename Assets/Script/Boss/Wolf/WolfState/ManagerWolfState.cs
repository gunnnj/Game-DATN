using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerWolfState
{
    public WolfBaseState CurrentState {get; private set;}

    public void InitializeState(WolfBaseState baseState)
    {
        CurrentState = baseState; 
        CurrentState.OnEnter();
        
    }

    public void ChangeState(WolfBaseState baseState)
    {
        CurrentState.OnExit();
        CurrentState = baseState;
        CurrentState.OnEnter();
        
    }

}
