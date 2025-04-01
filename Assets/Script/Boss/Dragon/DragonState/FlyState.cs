namespace Script.Boss.Dragon.DragonState
{
    public class FlyState : BaseState
    {
        public FlyState(DragonController dragonController, DragonData dragonData, string animationName) : base(dragonController, dragonData, animationName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            DragonController.Animatior.SetBool("IsGrounded", false);
            DragonController.Animatior.SetBool("Fly", true);
        }
        
        public override void OnExecute()
        {
            base.OnExecute();
            DragonController.SetMovementToTarget();
            if (DragonController.IsChangeState)
            {
                DragonController.DragonEnum state = DragonController.GetRadomState();   
                DragonController.ResetTimeChangeState();
                
                if (state == DragonController.DragonEnum.Ground)
                {
                    DragonController.Animatior.SetBool("IsGrounded", false);
                    DragonController.ManagerState.ChangeState(DragonController.WalkState);
                }
            }
            if (DragonController.IsAttack)
            {
                DragonController.ManagerState.ChangeState(DragonController.AttackFlyState);
            }
            
            
            
            
        }

        public override void OnExit()
        {
            DragonController.Animatior.SetBool("Fly", false);
        }
    }
}