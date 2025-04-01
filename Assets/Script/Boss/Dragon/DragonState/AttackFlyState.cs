using UnityEngine;

namespace Script.Boss.Dragon.DragonState
{
    public class AttackFlyState : FlyState
    {
        public AttackFlyState(DragonController dragonController, DragonData dragonData, string animationName) : base(dragonController, dragonData, animationName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            DragonController.Animatior.SetBool("Attack", true);
            DragonController.DragonMovement.SetDirection(Vector3.zero);
           
        }
        
        public override void OnExecute()
        {
            if (!DragonController.IsAttack)
            {
                DragonController.ManagerState.ChangeState(DragonController.FlyState);
            }
            if (DragonController.IsChangeState)
            {
                DragonController.DragonEnum state = DragonController.GetRadomState();   
                
                if (state == DragonController.DragonEnum.Ground)
                {
                    
                    DragonController.Animatior.SetBool("IsGrounded", false);
                    DragonController.Animatior.SetBool("Attack", false);
                    DragonController.ManagerState.ChangeState(DragonController.WalkState);
                }
            }
            
        }


        public override void OnExit()
        {
            base.OnExit();
            DragonController.Animatior.SetBool("Attack", false);
            DragonController.DragonEffect.TurnOffGatherEnegy();
            
        }
    }
}