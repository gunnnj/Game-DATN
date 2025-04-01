using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.ObjectPooling
{
    public class EffectLineUpPooling : MonoBehaviour
    {
        private Dictionary<string, EffectPooling> objectPools;
        public static EffectLineUpPooling Instance;
        private void Awake()
        {
            objectPools = new Dictionary<string, EffectPooling>();
            for (int i = 0; i < transform.childCount; i++)
            {
                objectPools[transform.GetChild(i).name] = transform.GetChild(i).GetComponent<EffectPooling>();
            }
            Instance = this;
        }

        public void SpawnEffect(string pooledObjectName, Transform parent, float timeExist)
        {
            GameObject effect =  objectPools[pooledObjectName].GetPooledObject();
            effect.transform.position = parent.position;
            effect.transform.rotation = parent.rotation;
            effect.transform.SetParent(parent);
            
            effect.SetActive(true);
            StartCoroutine(ReturnToPoolCoroutine(effect, timeExist));
        }

        private IEnumerator ReturnToPoolCoroutine(GameObject effect, float timeExist)
        {
            yield return new WaitForSeconds(timeExist);
            ReturnToPool(effect);
        }

        public void ReturnToPool(GameObject pooledObject)
        {
            objectPools[pooledObject.name].ReturnToPool(pooledObject);
        }
    }
}