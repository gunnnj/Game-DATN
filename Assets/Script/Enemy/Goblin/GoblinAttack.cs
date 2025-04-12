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
        if (other.CompareTag("Player") && GetComponentInParent<EnemyControl>().Target == other.transform && Vector3.Distance(transform.position,other.transform.position)<=range )
        {
            // if( Vector3.Distance(transform.position,other.transform.position)<=range){
            //     Debug.Log("AttackPlayer");
            //     OnAttack(other.gameObject);
            // }
            OnAttack(other.gameObject);
            
        }
        else if(other.CompareTag("MainHouse")&& GetComponentInParent<EnemyControl>().Target == other.transform){
            OnAttack(other.gameObject);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }


}