namespace Script.Player.Soldier.SoldierState
{
    public class BaseState
    {
        protected SoldierController soldierController;
        protected SoldierData soldierData;
        protected ManagerState managerState;
        protected string animaName;

        public BaseState(SoldierController soldierController, SoldierData soldierData, ManagerState managerState, string animName)
        {
            this.soldierController = soldierController;
            this.soldierData = soldierData;
            this.managerState = managerState;
            this.animaName = animName;
        }

        public virtual void OnEnter() { 
            soldierController.Animator.SetBool(animaName, true);
    
        }

        public virtual void OnExecute() {
            //Chuyen State 
        }

        public virtual void OnExit() {
            soldierController.Animator.SetBool(animaName, false);

        }
    }
}
