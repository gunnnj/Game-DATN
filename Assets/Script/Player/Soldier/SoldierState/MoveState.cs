using System;
using UnityEngine;

namespace Script.Player.Soldier.SoldierState
{
    public class MoveState : BaseState
    {
        public MoveState(SoldierController soldierController, SoldierData soldierData, ManagerState managerState, string animName) : base(soldierController, soldierData, managerState, animName)
        {
        }

        public override void OnExecute()
        {
            base.OnExecute();


        
            if (soldierController.DirectionMovement.magnitude <= 0.3f)
            {
                managerState.ChangeState(soldierController.Idle);
            }

            RotateDirection();
        }


        public void RotateDirection()
        {
            if (soldierController.DirectionMovement != Vector3.zero)
            {
                Quaternion rotate = Quaternion.LookRotation(soldierController.DirectionMovement);
                soldierController.RB.rotation = rotate;
            }

        }

    }
}
