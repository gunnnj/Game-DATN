using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public WolfMagicEffect wolfMagicEffect;
    public WolfMovement WolfMovement { get; private set; }
    public Animator Animatior { get; private set; }
    public WolfData WolfData { get; private set; }
    public ManagerWolfState  ManagerWolfState { get; private set; }
    public WolfIdleState WolfIdleState { get; private set; }
    public WolfAttackState WolfAttackState { get; private set; }
    public WolfBlockState WolfBlockState { get; private set; }
    public WolfDeadState WolfDeadState { get; private set; }
    public Transform Target { get; private set; }
    public bool IsAttack {get;set;}
    public bool isLowHP = false;
    public bool isShieldOn = true;

    public void Awake()
    {
        IsAttack =  false;
        wolfMagicEffect = GetComponent<WolfMagicEffect>();
        Animatior = GetComponent<Animator>();
        WolfData = GetComponent<WolfData>();
        WolfMovement = GetComponent<WolfMovement>();
        ManagerWolfState = new ManagerWolfState();
        WolfIdleState = new WolfIdleState(this, WolfData,"IdleMage");
        WolfAttackState = new WolfAttackState(this, WolfData,"Attack");
        WolfBlockState = new WolfBlockState(this, WolfData, "WolfBlock");
        WolfDeadState = new WolfDeadState(this, WolfData, "WolfDead");
    }

    public void Start()
    {
        ManagerWolfState.InitializeState(WolfIdleState);
    }

    public void SetTarget(Transform target){
        this.Target = target;
    }

    private void FixedUpdate()
    {
        ManagerWolfState.CurrentState.OnExecute();
        LowHP();
        IsShieldOn();
    }
    public bool LowHP(){
        return isLowHP;
    }
    public bool IsShieldOn(){
        return isShieldOn;
    }

    public void SetMovementToTarget()
    {
        if (Target != null)
        {
            WolfMovement.SetDirection(Target.position - transform.position);
            
        }
    }


    //Add event of Animation
    public void RandomMagicSkillAOE(){

    }
    public void SpawnMagicAOE(){
        wolfMagicEffect.SetTargetMagic(Target);
    }
    public void SpawnMagicBall(){
        wolfMagicEffect.magicBall.SpawnAndAttackMagicBall();
    }
    public void FireMagicBall(){
        wolfMagicEffect.magicBall.target = Target;
        wolfMagicEffect.magicBall.SetFireMagic();
    }

    public void TurnOnShield(){
        wolfMagicEffect.TurnShield(true);
        StartCoroutine(TurnOffShieldByTime());
    }

    private IEnumerator TurnOffShieldByTime(){
        yield return new WaitForSeconds(3f);
        wolfMagicEffect.TurnShield(false);
        isShieldOn = false;
    }

}
