using Script.Enemy;
using UnityEngine;

public class FireDefend : MonoBehaviour
{
    public Transform positionFire;
    private LineRenderer line;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.enabled = false;
    }
    public void FireEnemy(Vector3 position){
        line.SetPosition(0,positionFire.position);
        Vector3 posEnemy = new Vector3(position.x,position.y+0.3f,position.z);
        line.SetPosition(1,posEnemy);
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.enabled = true;
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy") && other!=null){
            FireEnemy(other.transform.position);
            other.GetComponent<EnemyHealth>().Damage(0.2f);
            // if(other == null || !other.gameObject.activeSelf){
            //     line.enabled = false;
            //     Debug.Log(transform.name+"aaa");
            // }
            if(other.GetComponent<EnemyHealth>().isDead){
                line.enabled = false;
            }
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy")){
            line.enabled = false;
        }
    }
}
