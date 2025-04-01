using System;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    private EnemyMovement enemyMovement;
    [HideInInspector] public Animator animator;
    public bool isAttack = false;
    public Transform Target => target;
    protected Transform target;
    

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();

    }


    protected void Update()
    {
        
        ChangeState();
    }

    protected void ChangeState()
    {
        if(isAttack)
        {
            animator.SetBool("IsAttack", true);
            enemyMovement.SetDirection(Vector3.zero);
            
            
        }
        else
        {
            
            if (target != null)
            {
                animator.SetBool("IsMove", true);
                enemyMovement.SetDirection(target.position - this.transform.position);
               
            }
            else
            {
                animator.SetBool("IsMove", false);
            }
            animator.SetBool("IsAttack", false);
        }
       
    }
    public void SetTarget(Transform transPlayer)
    {

        if(transPlayer != null)
        {
            target = transPlayer;
            enemyMovement.SetDirection(target.position - this.transform.position);
        }
        else
        {
            target = null;
            enemyMovement.SetDirection(Vector3.zero);
        }
    }

    

}