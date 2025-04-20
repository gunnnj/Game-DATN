using UnityEngine;

public  class GoblinAttack : EnemyAttack
{
    [SerializeField] public float range = 2f;
    protected override void OnAttack(GameObject gameObject)
    {
        
        base.OnAttack(gameObject);

    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainHouse") && GetComponentInParent<EnemyControl>().Target == other.transform && Vector3.Distance(transform.position,other.transform.position)<=range )
        {

            OnAttack(other.gameObject);
            
        }
        else if(other.CompareTag("Player")&& GetComponentInParent<EnemyControl>().Target == other.transform && other!=null){
            OnAttack(other.gameObject);
        }
    }

}