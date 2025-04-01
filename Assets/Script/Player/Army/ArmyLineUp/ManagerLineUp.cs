using UnityEngine;

namespace Script.Player.Army.ArmyLineUp
{
    public class ManagerLineUp 
    {
        public BaseLineUp CurrentLineUp;

        public void Initialize(BaseLineUp lineUp)
        {
            CurrentLineUp = lineUp;
            CurrentLineUp.OnEnterLineUp();
        }

        public void ChangeLineUp(BaseLineUp lineUp)
        {
            CurrentLineUp.OnExitLineUp();
            CurrentLineUp = lineUp;
            CurrentLineUp.OnEnterLineUp();
        }
        
    }
}