﻿using System.Collections.Generic;
using UnityEngine;

namespace TheSicker.Core
{
    public class ObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }

        // config
        [SerializeField] List<Pool> pools;
        
        // state
        private Dictionary<string, Queue<GameObject>> poolDictionary;

        // Start is called before the first frame update
        void Awake()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach(Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for(int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }
    
        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if(!poolDictionary.ContainsKey(tag)) return null;

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            // execute specific action on spawn
            IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();
            if(pooledObject != null)
            {
                pooledObject.OnObjectSpawn();
            }

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}
