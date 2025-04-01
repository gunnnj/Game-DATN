namespace Script.Player.Army.ArmyLineUp
{
    public class TriangleLineUp : BaseLineUp
    {
        public TriangleLineUp(ArmyPlayer controller) : base(controller)
        {
        }

        public override void OnEnterLineUp()
        {
            base.OnEnterLineUp();
            controller.SetTriangle();
            IncreaseDamage();
            this.SpawnEffect(LineUp.Triangle);
        }
        
        public override void OnExitLineUp()
        {
            base.OnExitLineUp();
            DecreaseDamage();
        }

        private void IncreaseDamage()
        {
            foreach (var soldier in soldiers)
            {
                float currentRangeAttack = soldier.SoldierData.RangeAttack;
                int currentDamage = soldier.SoldierData.Damage;
           
                soldier.SoldierData.SetDamage(currentDamage + currentDamage);
                soldier.SoldierData.SetRangeAttack(1.5f*currentRangeAttack);
              
            }
        }
        
        private void DecreaseDamage()
        {
            foreach (var soldier in soldiers)
            {
                float currentRangeAttack = soldier.SoldierData.RangeAttack;
                int currentDamage = soldier.SoldierData.Damage;
              
                soldier.SoldierData.SetDamage((int)(currentDamage/2));
                soldier.SoldierData.SetRangeAttack(currentRangeAttack/1.5f);
                
            }
        }
        
     


        
    }
}