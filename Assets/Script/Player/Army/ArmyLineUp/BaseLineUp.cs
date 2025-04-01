using System.Collections.Generic;
using Script.ObjectPooling;

namespace Script.Player.Army.ArmyLineUp
{
    public class BaseLineUp
    {
        protected ArmyPlayer controller;
        protected List<SoldierController> soldiers;
        protected BaseLineUp(ArmyPlayer controller)
        {
            this.controller = controller;
            soldiers = this.controller.Players;
        }

        public virtual void OnEnterLineUp()
        {
            
        }

        public virtual void OnExecuteLineUp()
        {
            
        }

        public virtual void OnExitLineUp()
        {
            
        }

        public void SpawnEffect(LineUp lineUp)
        {
            foreach (var soldier in soldiers)
            {
                EffectLineUpPooling.Instance.SpawnEffect(lineUp.ToString(),  soldier.transform, 2f);
            }
            
            
        }
    }
}