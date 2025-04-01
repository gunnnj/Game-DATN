using UnityEngine;

namespace Script.Boss.Dragon.DragonState
{
    public class GroundState : BaseState
    {
        public GroundState(DragonController dragonController, DragonData dragonData, string animationName) : base(dragonController, dragonData, animationName)
        {
            
        }
        
        public override void OnEnter()
        {
            DragonController.Animatior.SetBool("Ground", true);
        }
        
        public override void OnExit()
        {
            DragonController.Animatior.SetBool("Ground", false);
        }
        
    }
}