using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPoolingManager : MonoBehaviour
{
    [SerializeField] private int amountGoblin;
    [SerializeField] private float timeToSpawn;
    private Vector3 posSpawn;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        
        while(amountGoblin>0){   
            int dirX = Random.Range(1, 11);
            posSpawn = transform.position+ new Vector3(dirX,0f,0f);   
            EnemyPooling.Instance.SetPositionEnemy(posSpawn);
            yield return new WaitForSeconds(timeToSpawn);
            amountGoblin--;
        }
        
    }
}
