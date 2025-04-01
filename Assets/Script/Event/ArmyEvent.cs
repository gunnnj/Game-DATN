using Script.Player.Army;

namespace Script.Event
{
    public class ArmyEvent
    {
        public delegate void ChangeLineUp(LineUp lineUp);
        public static ChangeLineUp ChangeLineUpArmy;
    }
}