using UnityEngine;

namespace Script.Boss.Dragon.DragonState
{
    public class IdleState : BaseState
    {
        public IdleState(DragonController dragonController, DragonData dragonData, string animationName) : base(dragonController, dragonData, animationName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            DragonController.Animatior.SetBool("IsGrounded", true);
            DragonController.DragonMovement.SetDirection(Vector3.zero);
        }

        public override void OnExecute()
        {
            base.OnExecute();
            if (DragonController.Target != null)
            {
                DragonController.ManagerState.ChangeState(DragonController.WalkState);
            }

            if (DragonController.IsChangeState)
            {
                DragonController.DragonEnum state = DragonController.GetRadomState();   
                DragonController.ResetTimeChangeState();
                if (state == DragonController.DragonEnum.Ground)
                {
                    DragonController.ManagerState.ChangeState(DragonController.WalkState);
                }
                else if (state == DragonController.DragonEnum.Fly)
                {
                    DragonController.ManagerState.ChangeState(DragonController.FlyState);
                }
            }
           
        }
    }
}