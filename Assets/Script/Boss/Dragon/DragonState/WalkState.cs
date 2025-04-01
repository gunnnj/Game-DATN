using UnityEngine;

namespace Script.Boss.Dragon.DragonState
{
    public class WalkState : GroundState
    {
        public WalkState(DragonController dragonController, DragonData dragonData, string animationName) : base(dragonController, dragonData, animationName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            DragonController.Animatior.SetBool("Walk", true);
            
        }

        public override void OnExecute()
        {
            base.OnExecute();
            DragonController.SetMovementToTarget();
            if (DragonController.IsChangeState)
            {
                DragonController.DragonEnum state = DragonController.GetRadomState();   
                DragonController.ResetTimeChangeState();
                if (state == DragonController.DragonEnum.Idle)
                {
                    DragonController.ManagerState.ChangeState(DragonController.IdleState);
                }
                else if (state == DragonController.DragonEnum.Fly)
                {
                    DragonController.Animatior.SetBool("IsGrounded", true);
                    DragonController.ManagerState.ChangeState(DragonController.FlyState);
                }
            }

            if (DragonController.IsAttack)
            {
                DragonController.ManagerState.ChangeState(DragonController.AttackGroundState);
            }
            
            
        }


        public override void OnExit()
        {
            base.OnExit();
            DragonController.Animatior.SetBool("Walk", false);
        }
    }
}