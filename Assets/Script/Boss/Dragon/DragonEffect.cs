using UnityEngine;

namespace Script.Boss.Dragon.DragonState
{
    public class DragonEffect : MonoBehaviour
    {
        [SerializeField] private GameObject gatherEnegy;
        [SerializeField] private GameObject dragonBreath;
        [SerializeField] private GameObject dragonElectric;
        
        public void TurnOnGatherEnegy()
        {
            this.gatherEnegy.SetActive(true);
        }

        public void TurnOffGatherEnegy()
        {
            this.gatherEnegy.SetActive(false);
        }

        public void TurnOnDragonBreath()
        {
            this.dragonBreath.SetActive(true);
        }

        public void TurnOffDragonBreath()
        {
            this.dragonBreath.SetActive(false);
        }

        public void TurnOnDragonElectric()
        {
            this.dragonElectric.SetActive(true);
        }

        public void TurnOffDragonElectric()
        {
            this.dragonElectric.SetActive(false);
        }
    }
}