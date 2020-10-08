using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        // config
        [SerializeField] float timeBetweenSpawns = 5f;

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
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer > timeBetweenSpawns)
            {
                _objectPooler.SpawnFromPool("FollowOnDistanceAttacker", transform.position, Quaternion.identity);
                spawnTimer = 0;
            }
        }
    }
}
