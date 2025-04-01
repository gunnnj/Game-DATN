using System.Collections.Generic;

namespace Script.Player.Army.ArmyLineUp
{
    public class HorizontalLineUp : BaseLineUp
    {

        private float timeHeal = 1f;
        
        
        public HorizontalLineUp(ArmyPlayer controller) : base(controller)
        {
            
        }

        public override void OnEnterLineUp()
        {
            base.OnEnterLineUp();
            controller.SetHorizontal();
            InscreaseArmor();
            this.SpawnEffect(LineUp.Horizontal);
        }

        public override void OnExecuteLineUp()
        {
            base.OnExecuteLineUp();
            if (timeHeal <= 0)
            {
                Heal();
                timeHeal = 1f;
            }
            else
            {
                timeHeal -= 1f;
            }
        }

        public override void OnExitLineUp()
        {
            base.OnExitLineUp();
            DecreaseArmor();
        }

        private void InscreaseArmor()
        {
            foreach (var soldier in soldiers)
            {
                int currentArmor = soldier.SoliderHealth.Armor;
                soldier.SoliderHealth.InscreseArmor(currentArmor);
            }
        }

        private void DecreaseArmor()
        {
            foreach (var soldier in soldiers)
            {
                int currentArmor = soldier.SoliderHealth.Armor;
                soldier.SoliderHealth.DecreaseArmor(-currentArmor);
            }
        }

        private void Heal()
        {
            foreach (var soldier in soldiers)
            {
                soldier.SoliderHealth.Heal(5);
            }
        }


        
        
    }
}