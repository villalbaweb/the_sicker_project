using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheSicker.Core
{
    public class ObjectPoolSpawner : MonoBehaviour
    {
        // config
        [Header("Object Spawn Settings")]
        [SerializeField] float timeBetweenSpawns = 5f;
        [SerializeField] List<ObjectPoolIds> availableObjectstoSpawn = new List<ObjectPoolIds>();

        [Header("Object Spawn Position")]
        [SerializeField] float viewportToWorldZPos = 10.0f;

        // cache
        ObjectPooler _objectPooler;
        ObjectPoolSpawnerLevelHandler _objectPoolSpawnerLevelHandler;

        // state
        float spawnTimer = Mathf.Infinity;

        private void Awake() 
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();
            _objectPoolSpawnerLevelHandler = GetComponent<ObjectPoolSpawnerLevelHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            PoolObjectSpawn();
        }

        private void PoolObjectSpawn()
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer > GetTimeToSpawnBasedOnGameLevel())
            {
                _objectPooler.SpawnFromPool(RandomObjectToSpawn(), GetRandomPos(), Quaternion.identity);
                spawnTimer = 0;
            }
        }

        private float GetTimeToSpawnBasedOnGameLevel()
        {
            return _objectPoolSpawnerLevelHandler 
                ? _objectPoolSpawnerLevelHandler.GameLevelBasedTimeToSpawn 
                : timeBetweenSpawns;
        }

        private Vector3 GetRandomPos()
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(CalculateRandomViewportPos(), CalculateRandomViewportPos(), viewportToWorldZPos));
        }

        private float CalculateRandomViewportPos()
        {
            return Random.Range(0f, 1f) >= 0.5f ? Random.Range(1f, 2f) : Random.Range(-1f, 0f);
        }

        private string RandomObjectToSpawn()
        {
            return availableObjectstoSpawn
                .Take(_objectPoolSpawnerLevelHandler ? _objectPoolSpawnerLevelHandler.GameLevel + 1 : 1)
                .OrderBy(x => System.Guid.NewGuid())
                .FirstOrDefault()
                .ToString();
        }
    }
}
