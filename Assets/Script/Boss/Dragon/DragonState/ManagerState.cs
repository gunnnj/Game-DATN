namespace Script.Boss.Dragon.DragonState
{
    public class ManagerState
    {
        public BaseState CurrentState { get; private set; }

        public void InitializeState(BaseState baseState)
        {
            CurrentState = baseState; 
            CurrentState.OnEnter();
            
        }

        public void ChangeState(BaseState baseState)
        {
            CurrentState.OnExit();
            CurrentState = baseState;
            CurrentState.OnEnter();
            
        }
    }
}