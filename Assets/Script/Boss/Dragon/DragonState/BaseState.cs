namespace Script.Boss.Dragon.DragonState
{
    public class BaseState
    {
        protected DragonController DragonController;
        protected DragonData DragonData;
        private string animationName;


        public BaseState(DragonController dragonController, DragonData dragonData, string animationName)
        {
            this.DragonController = dragonController;
            this.DragonData = dragonData;
            this.animationName = animationName;
        }


        public virtual void OnEnter()
        {
            DragonController.Animatior.SetBool(animationName, true);
            
            
        }
        public virtual void OnExecute(){}

        public virtual void OnExit()
        {
            
            DragonController.Animatior.SetBool(animationName, false);
        }
    }
}