using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Golem : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform house;
    public Transform army;
    public Transform target;
    public Animator animator;
    public SphereCollider sphereCollider;
    public GameObject effectImpact;
    [SerializeField] float rangeFind = 20f;
    [SerializeField] float rangeAttack = 5f;
    private float originSpeed;
    private const string animWalk = "IsMove";
    private const string animAttack = "IsAttack";
    private float rangeAttackHouse = 14f;
    private float rangeAttackArmy = 5f;
    public bool offSound;

    void Awake()
    {
        sphereCollider.enabled = false;
        offSound = false;
    }
    void OnEnable()
    {
        GameEvent.loseGame += OffSoundLose;
        GameEvent.winGame += OffSoundWin;
    }
    void OnDisable()
    {
        GameEvent.loseGame -= OffSoundLose;
        GameEvent.winGame -= OffSoundWin;
    }
    public void OffSoundLose(int type){
        offSound = true;
    }
    public void OffSoundWin(){
        offSound = true;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        effectImpact.SetActive(false);
        // target = house;
        originSpeed = agent.speed;
    }
    void Update()
    {
        

        if(Vector3.Distance(transform.position,army.position)<rangeFind){
            target = army;
            rangeAttack = rangeAttackArmy;
        }else{
            target = house;
            rangeAttack = rangeAttackHouse;
        }

        if(Vector3.Distance(transform.position,target.position)<rangeAttack){
            agent.speed = 0;
            animator.SetBool(animAttack,true);
        }
        else{
            agent.speed = originSpeed;
            animator.SetBool(animAttack,false);
        }
        if(agent.speed>0){
            animator.SetBool(animWalk,true);
        }
        else{
            animator.SetBool(animWalk,false);
        }

        agent.SetDestination(target.position);

    }


    // Event of Animation attack
    public void SpawnEffect(){
        effectImpact.SetActive(true);
        sphereCollider.enabled =true;
        if(!offSound){
            AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Earthquake);
        }
        
    }

    //Event of Animation attack end
    public void DisActiveCollier(){
        sphereCollider.enabled = false;
    }
}
