using System.Collections.Generic;
using UnityEngine;

namespace TheSicker.Core
{
    public class ObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public ObjectPoolIds tag;
            public GameObject prefab;
            public int size;
        }

        // config
        [SerializeField] List<Pool> pools = null;
        
        // state
        private Dictionary<string, Queue<GameObject>> poolDictionary;
        GameObject _objectsPoolParent;

        // consts
        const string OBJECT_POOL_PARENT_NAME = "Objects Pool";

        // Start is called before the first frame update
        void Awake()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();
            _objectsPoolParent = CreateCustomObjectPoolParent(OBJECT_POOL_PARENT_NAME);

            foreach(Pool pool in pools)
            {
                GameObject objectPoolDivision = CreateCustomObjectPoolParent(pool.tag.ToString());
                objectPoolDivision.transform.parent = _objectsPoolParent.transform;
                
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for(int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    obj.transform.parent = objectPoolDivision.transform;
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag.ToString(), objectPool);
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

        private GameObject CreateCustomObjectPoolParent(string parentName)
        {
            GameObject parent = GameObject.Find(parentName);

            if (!parent)
            {
                parent = new GameObject(parentName);
            }

            return parent;
        }
    }
}
