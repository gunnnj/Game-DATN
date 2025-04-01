


using UnityEngine;

namespace Script.Player.Soldier.SoldierState
{
    public class AttackState : BaseState
    {


        public AttackState(SoldierController soldierController, SoldierData soldierData, ManagerState managerState,
            string animName) : base(soldierController, soldierData, managerState, animName)
        {



        }

        public override void OnEnter()
        {
            base.OnEnter();
            soldierController.Animator.speed = soldierData.SpeedAttack;
        }


        public override void OnExecute()
        {
            base.OnExecute();


            if (soldierController.DirectionMovement.magnitude > 0.3)
            {
                managerState.ChangeState(soldierController.Move);
            }

            if (CheckDistance())
            {

                managerState.ChangeState(soldierController.Idle);

            }


            RotateDirectionAttack();


        }

        public override void OnExit()
        {
            base.OnExit();
            soldierController.Animator.speed = 1;
        }

        private bool CheckDistance()
        {
            Vector3 start = soldierController.transform.position;
            Vector3 end = soldierController.target.position;
            start.y = 0;
            end.y = 0;

            return Vector3.Distance(start, end) > soldierData.RangeAttack;

        }

        private void RotateDirectionAttack()
        {
            Vector3 dir = (soldierController.target.position - soldierController.transform.position).normalized;
            Quaternion rotate = Quaternion.LookRotation(dir);
            soldierController.RB.rotation = rotate;
        }
    }

}

   
