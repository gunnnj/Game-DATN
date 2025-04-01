using System.Collections.Generic;
using UnityEngine;

namespace Script.Player.Army.ArmyLineUp
{
    public class VerticalLineUp : BaseLineUp
    {
      
        public VerticalLineUp(ArmyPlayer controller) : base(controller)
        {
            
        }

        public override void OnEnterLineUp()
        {
            base.OnEnterLineUp();
            controller.SetVertical();
            IncreaseSpeed();
            IncreaseDodge();
            this.SpawnEffect(LineUp.Vertical);
            
        }


        public override void OnExitLineUp()
        {
            base.OnExitLineUp();
            DecreaseSpeed();
            DecreaseDodge();
        }

        private void IncreaseDodge()
        {
            foreach (var soldier in soldiers)
            {
                float currentRateDodge = soldier.SoliderHealth.RateDodge;
                soldier.SoliderHealth.Dodge(currentRateDodge);
            }
        }
        
        private void DecreaseDodge()
        {
            foreach (var soldier in soldiers)
            {
                float currentRateDodge = soldier.SoliderHealth.RateDodge;
                soldier.SoliderHealth.Dodge(-currentRateDodge);
            }
        }


        private void IncreaseSpeed()
        {
            controller.ArmyMovement.SetSpeed(2f);
        }
        
        private void DecreaseSpeed()
        {
            controller.ArmyMovement.SetSpeed(0.5f);
        }
    }
}