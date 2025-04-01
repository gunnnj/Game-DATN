using UnityEngine;

namespace Script.Boss.Dragon.DragonState
{
    public class AttackGroundState : GroundState
    {
        public AttackGroundState(DragonController dragonController, DragonData dragonData, string animationName) : base(dragonController, dragonData, animationName)
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
                DragonController.ManagerState.ChangeState(DragonController.WalkState);
            }
            
            if (DragonController.IsChangeState)
            {
                DragonController.DragonEnum state = DragonController.GetRadomState();   
                
                if (state == DragonController.DragonEnum.Fly)
                {
                    
                    DragonController.Animatior.SetBool("IsGrounded", true);
                    DragonController.Animatior.SetBool("Attack", false);
                    DragonController.ManagerState.ChangeState(DragonController.FlyState);
                }
            }
            
           
            
        }


        public override void OnExit()
        {
            base.OnExit();
            DragonController.Animatior.SetBool("Attack", false);
            DragonController.DragonEffect.TurnOffGatherEnegy();
            DragonController.DragonEffect.TurnOffDragonBreath();
            DragonController.DragonEffect.TurnOffDragonElectric();
        }
    }
}