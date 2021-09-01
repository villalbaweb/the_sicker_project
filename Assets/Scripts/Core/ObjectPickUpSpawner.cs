using System.Collections.Generic;
using System.Linq;
using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Core
{
    public class ObjectPickUpSpawner : MonoBehaviour
    {
                // config
        [SerializeField] float timeBetweenSpawns = 5f;
        [SerializeField] List<ObjectPoolIds> availablePickUps = new List<ObjectPoolIds>();

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
            SpawnPickUp();
        }

        private void SpawnPickUp()
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer > timeBetweenSpawns)
            {
                _objectPooler.SpawnFromPool(RandomPickUpToSpawn(), GetRandomPos(), Quaternion.identity);
                spawnTimer = 0;
            }
        }

        private Vector3 GetRandomPos()
        {
            float xValue = Random.Range(0f, 1f);
            float yValue = Random.Range(0f, 1f);

            return Camera.main.ViewportToWorldPoint(new Vector3(xValue, yValue, Camera.main.nearClipPlane));
        }

        private string RandomPickUpToSpawn()
        {
            return availablePickUps.OrderBy(x => System.Guid.NewGuid()).FirstOrDefault().ToString();
        }
    }
}
