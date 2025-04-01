using UnityEngine;

public class ZombieExplodeAttack : EnemyAttack
{
    public GameObject explode;
    protected override void OnAttack(GameObject target)
    {
        base.OnAttack(target);
        
        Invoke(nameof(DestroyEnemy),.5f);
    }

    public void DestroyEnemy(){
        Instantiate(explode,transform.position,Quaternion.identity);
        transform.parent.gameObject.SetActive(false);
        Debug.Log("Take dame player");
    }
}