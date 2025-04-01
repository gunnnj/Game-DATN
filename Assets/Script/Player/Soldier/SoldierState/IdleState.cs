namespace Script.Player.Soldier.SoldierState
{
    public class IdleState : BaseState
    {
        public IdleState(SoldierController soldierController, SoldierData soldierData, ManagerState managerState, string animName) : base(soldierController, soldierData, managerState, animName)
        {
        }

        public override void OnExecute()
        {
            base.OnExecute();
            if(soldierController.DirectionMovement.magnitude > 0.3f)
            {
                managerState.ChangeState(soldierController.Move);
            }
      
        }
    }
}
