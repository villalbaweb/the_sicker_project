using TheSicker.Core;
using TheSicker.GameDifficulty;
using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Attacks
{
    public class FollowOnDistanceExplosiveSpecialAttack : MonoBehaviour
    {
        // config
        [SerializeField] int defaultExplosionDamage = 50;
        [SerializeField] UnityEvent onExplosionAttack = null;

        // cache
        GameDifficultyDamageLevelProvider _gameDifficultyDamageLevelProvider;

        private void Awake()
        {
            _gameDifficultyDamageLevelProvider = GetComponent<GameDifficultyDamageLevelProvider>();
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.tag != "Player") return;

            int damage = _gameDifficultyDamageLevelProvider ? _gameDifficultyDamageLevelProvider.GetDamageLevel() : defaultExplosionDamage;
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            onExplosionAttack?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
