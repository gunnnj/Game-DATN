using Script.Weapon;
using UnityEngine;

namespace Script.ObjectPooling
{
    public class WeaponPooling : ObjectPooling
    {   
        public static ObjectPooling Instance;

        public override void Awake()
        {
            base.Awake();
            Instance = this;
        }

        
    }
}