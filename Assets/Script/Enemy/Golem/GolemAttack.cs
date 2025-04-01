using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : EnemyAttack
{
    private Animator animator;
    private EnemyControl enemyControl;
    public SphereCollider impactLeg;
    public SphereCollider impactHand;
    public GameObject effectImpact;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        enemyControl = GetComponentInParent<EnemyControl>();
        effectImpact.SetActive(false);
    }
    protected override void OnAttack(GameObject gameObject)
    {
        base.OnAttack(gameObject);

    }

    void FixedUpdate()
    {
        if(enemyControl.isAttack){
            
        }
    }

    
}
