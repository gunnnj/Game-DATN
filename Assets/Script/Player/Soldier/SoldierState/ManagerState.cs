namespace Script.Player.Soldier.SoldierState
{
    public class ManagerState
    {
        public BaseState CurrentState {  get; set; }


        public void Initilize(BaseState state)
        {
            CurrentState = state;
            CurrentState.OnEnter();
        }

        public void ChangeState(BaseState newState)
        {
            CurrentState.OnExit();
            CurrentState = newState;
            CurrentState.OnEnter();
        }
    }
}
