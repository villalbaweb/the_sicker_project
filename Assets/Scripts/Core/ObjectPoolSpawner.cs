using System.Collections.Generic;
using System.Linq;
using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Core
{
    public class ObjectPoolSpawner : MonoBehaviour
    {
        // config
        [SerializeField] float timeBetweenSpawns = 5f;
        [SerializeField] List<ObjectPoolIds> availableObjectstoSpawn = new List<ObjectPoolIds>();

        // cache
        ObjectPooler _objectPooler;

        // state
        float spawnTimer = Mathf.Infinity;

        private void Awake() 
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();    
        }

        // Update is called once per frame
        void Update()
        {
            PoolObjectSpawn();
        }

        private void PoolObjectSpawn()
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer > timeBetweenSpawns)
            {
                _objectPooler.SpawnFromPool(RandomObjectToSpawn(), GetRandomPos(), Quaternion.identity);
                spawnTimer = 0;
            }
        }

        private Vector3 GetRandomPos()
        {
            float xValue = Random.Range(0f, 1f);
            float yValue = Random.Range(0f, 1f);

            return Camera.main.ViewportToWorldPoint(new Vector3(xValue, yValue, Camera.main.nearClipPlane));
        }

        private string RandomObjectToSpawn()
        {
            return availableObjectstoSpawn.OrderBy(x => System.Guid.NewGuid()).FirstOrDefault().ToString();
        }
    }
}
