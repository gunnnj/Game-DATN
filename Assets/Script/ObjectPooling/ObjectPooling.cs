using System.Collections.Generic;
using UnityEngine;

namespace Script.ObjectPooling
{
    public class ObjectPooling : MonoBehaviour
    {
        
        public List<GameObject> pooledObjects;
        [SerializeField]private GameObject objectToPool;
     
        

        public virtual void Awake()
        {
          
            pooledObjects = new List<GameObject>();
        }
        
        public virtual GameObject GetPooledObject()
        {
            for(int i = 0; i < pooledObjects.Count; i++)
            {
                if(!pooledObjects[i].activeSelf)
                {
                    return pooledObjects[i];
                }
            }
            
            GameObject objectPool = Instantiate(objectToPool, transform);
            objectPool.name = objectToPool.name;
            
            pooledObjects.Add(objectPool);
            return objectPool;
        }


        public void SetObjectPool(GameObject objectPool)
        {
            this.objectToPool = objectPool;
        }


        
    }
}