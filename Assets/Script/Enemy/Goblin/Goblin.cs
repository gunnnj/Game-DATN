using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform house;
    public Transform army;
    public Transform target;
    public Animator animator;
    public BoxCollider weapon;
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
        weapon.enabled = false;
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
        originSpeed = agent.speed;
        
        rangeAttack = rangeAttackArmy;
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
    //Add event anim
    public void EventStartAttack(){
        weapon.enabled = true;
        if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.ThrowWeapon);
    }
    public void EventEndAttack(){
        weapon.enabled = false;
    }

}
