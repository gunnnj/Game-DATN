using UnityEngine;

namespace Script.Player.Army.ArmyLineUp
{
    public class RectangleLineUp : BaseLineUp
    {
        public RectangleLineUp(ArmyPlayer controller) : base(controller)
        {
        }

        public override void OnEnterLineUp()
        {
            
            base.OnEnterLineUp();
            controller.SetRectangle();
           
            IncreaseSpeed();
            this.SpawnEffect(LineUp.Rectangle);
        }
        
        
        

        public override void OnExitLineUp()
        {
            base.OnExitLineUp();
            DeceaseSpeed();
        }

        private void IncreaseSpeed()
        {
            foreach (var soldier in soldiers)
            {
                float currentSpeed = soldier.SoldierData.SpeedAttack;
                soldier.SoldierData.SetSpeedAttack(currentSpeed * 2f);
            }
        }

        private void DeceaseSpeed()
        {
            foreach (var soldier in soldiers)
            {
                float currentSpeed = soldier.SoldierData.SpeedAttack;
                soldier.SoldierData.SetSpeedAttack(currentSpeed / 2f);
            }
        }
        

}
}