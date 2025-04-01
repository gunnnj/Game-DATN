using System;
using System.Collections.Generic;
using UnityEngine;




namespace Script.ObjectPooling
{
    public enum TypeBullet
    {
        DragonBall = 0,
    }
    
    
    public class BulletPooling : MonoBehaviour
    {
        [SerializeField] private GameObject dragonBullet;
        public static BulletPooling Instance;
        private Dictionary<TypeBullet, ObjectPooling> pools;
        
        private void Awake()
        {
            Instance = this;
            pools = new  Dictionary<TypeBullet, ObjectPooling>();
        }

        private void Start()
        {
            GenerateDragonPool();
            
            
            
        }

        private void GenerateDragonPool()
        {
            GameObject dragonBall = new GameObject("DragonBall");
            
            dragonBall.AddComponent<ObjectPooling>();
            dragonBall.GetComponent<ObjectPooling>().SetObjectPool(dragonBullet);
            pools.Add(TypeBullet.DragonBall, dragonBall.GetComponent<ObjectPooling>());
            
        }

        public GameObject SpawnBullet(TypeBullet typeBullet)
        {
            return pools[typeBullet].GetPooledObject();
        }
        
        
        
    }
}