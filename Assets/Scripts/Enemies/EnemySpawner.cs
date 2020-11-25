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
                _objectPooler.SpawnFromPool(ObjectPoolIds.FollowOnDistanceAttacker.ToString(), GetRandomPos(), Quaternion.identity);
                spawnTimer = 0;
            }
        }

        private Vector3 GetRandomPos()
        {
            float xValue = Random.Range(0f, 1f);
            float yValue = Random.Range(0f, 1f);

            return Camera.main.ViewportToWorldPoint(new Vector3(xValue, yValue, Camera.main.nearClipPlane));
        }
    }
}
