using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPoolingManager : MonoBehaviour
{
    [SerializeField] private int amountEnemy;
    [SerializeField] private float timeToSpawn;
    [SerializeField] public EnemyPooling[] enemyPoolings;
    public SpawnBoss spawnBoss;
    private Vector3 posSpawn;
    // private bool isSpawn =false;
    public static EnemyPoolingManager Instance;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {

    }
    [ContextMenu("Spawn")]
    public void StartSpawn()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int id = amountEnemy;
        while(id>0){   
            int dirX = Random.Range(1, 11);
            posSpawn = transform.position+ new Vector3(dirX,0f,0f);   
            enemyPoolings[0].SetPositionEnemy(posSpawn);
            dirX = Random.Range(1, 11);
            posSpawn = transform.position+ new Vector3(dirX,0f,0f);  
            enemyPoolings[1].SetPositionEnemy(posSpawn);
            yield return new WaitForSeconds(timeToSpawn);
            id--;
        }
        
    }
    [ContextMenu("SpawnBoss")]
    public void SpawnBoss(){
        spawnBoss.SpawnBossArc(transform.position);
    }
}
