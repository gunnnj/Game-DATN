

using Script.Boss.Dragon.DragonState;
using Script.Bullet;
using Script.ObjectPooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Boss.Dragon
{
    public class DragonController : MonoBehaviour
    {

        public Transform positionOffset;
        
        public LayerMask layerGroundMask;
        public Animator Animatior { get; private set; }
        public DragonData DragonData { get; private set; }
        public DragonMovement DragonMovement { get; private set; }
        
        public DragonEffect DragonEffect { get; private set; }  
        
        
      
        public enum DragonEnum
        {
            Idle,
            Ground, 
            Fly
        }

        private float timeRandomState = 12f;
        public bool IsChangeState => timeRandomState < 0;
        public void ResetTimeChangeState() => timeRandomState = 12f;
        public bool IsAttack { get; set; }
         

        #region State Machine
        public ManagerState  ManagerState { get; private set; }
        public IdleState  IdleState { get; private set; }
        public FlyState  FlyState { get; private set; } 
        public WalkState  WalkState { get; private set; }
        public AttackGroundState AttackGroundState { get; private set; }
        public AttackFlyState AttackFlyState { get; private set; }
        #endregion

        public Transform Target { get; private set; }

        
        private void Awake()
        {
            IsAttack = false;
            Animatior = GetComponent<Animator>();
            DragonData = GetComponent<DragonData>();
            DragonMovement =  GetComponent<DragonMovement>();
            DragonEffect = GetComponent<DragonEffect>();
            ManagerState = new ManagerState(); 
            IdleState = new IdleState(this, DragonData, "Idle" );
            WalkState = new WalkState(this, DragonData, "Ground" );
            AttackGroundState = new AttackGroundState(this, DragonData, "Ground" );
            FlyState = new FlyState(this, DragonData, "Fly");
            AttackFlyState = new AttackFlyState(this, DragonData, "Fly");
        }

        private void Start()
        {
            
            ManagerState.InitializeState(IdleState);
            
        }


        private void FixedUpdate()
        {
            ManagerState.CurrentState.OnExecute();
            CaculateChangeState();
        }

        private void CaculateChangeState()
        {
            if (!IsChangeState)
            {
                this.timeRandomState -= Time.deltaTime;
            }
            
        }

        public void SetTarget(Transform target)
        {
            this.Target = target;
        }
        
        
        

        public void SetMovementToTarget()
        {
            if (Target != null)
            {
                DragonMovement.SetDirection(Target.position - transform.position);
            }
            else
            {
                DragonMovement.RandomMovement();
            }
            
            
            
        }
        
        
        
        

        public DragonEnum GetRadomState()
        {
            int radomIndex = Random.Range(0, 10);
            if (Target == null)
            {
                if (radomIndex < 3)
                {
                    return DragonEnum.Idle;
                }
                else if(radomIndex <= 5)
                {
                    return DragonEnum.Ground;
                }
                else
                {
                    return DragonEnum.Fly;
                }
            }
            else
            {
                if (radomIndex < 5)
                {
                    return DragonEnum.Ground;
                }
                else
                {
                    return DragonEnum.Fly;
                }
            }
            
        }


        public void SpawnDragonBall()
        {
            GameObject bulletDragon = BulletPooling.Instance.SpawnBullet(TypeBullet.DragonBall);
            bulletDragon.SetActive(false);
            bulletDragon.GetComponent<BulletMovement>().SetMovement(positionOffset.position, Target.position,DragonData.attackSpeed);
            bulletDragon.GetComponent<BulletDamage>().SetTarget(DragonData.attackDamage, "Player");
            bulletDragon.SetActive(true);
        }

    }
}