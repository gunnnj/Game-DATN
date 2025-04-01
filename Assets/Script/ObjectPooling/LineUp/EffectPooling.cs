using UnityEngine;

namespace Script.ObjectPooling
{
    public class EffectPooling : ObjectPooling
    {
        public void ReturnToPool(GameObject pooledObject)
        {
            if (this.pooledObjects.Contains(pooledObject))
            {
                pooledObject.transform.SetParent(this.transform);
                pooledObject.SetActive(false);
            }
        }
    }
}