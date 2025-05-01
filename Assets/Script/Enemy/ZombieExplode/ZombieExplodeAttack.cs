using Unity.VisualScripting;
using UnityEngine;

public class ZombieExplodeAttack : EnemyAttack
{
    public GameObject explode;
    private bool isExplode;
    protected override void OnAttack(GameObject target)
    {
        base.OnAttack(target);
        
        Invoke(nameof(DestroyEnemy),.5f);
    }

    public void DestroyEnemy(){
        if(isExplode) return;
        Instantiate(explode,transform.position,Quaternion.identity);
        isExplode = true;
        transform.parent.gameObject.SetActive(false);
        // Debug.Log("Take dame player");
    }
    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.CompareTag("Player")){
    //         other.GetComponent<IHealthDamage>().Damage(damage);
    //     }
    // }
}