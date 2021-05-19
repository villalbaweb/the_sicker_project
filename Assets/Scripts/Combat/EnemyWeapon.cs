using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Combat
{
    [CreateAssetMenu(fileName = "EnemyWeapon", menuName = "Weapons/Make New Enemy Weapon", order = 1)]
    public class EnemyWeapon : ScriptableObject
    {
        // config
        [SerializeField] ObjectPoolIds projectile = ObjectPoolIds.EnemyBlueProjectile;
        [SerializeField] float projectileFiringPeriod = 0.1f;
        [SerializeField] AudioClip onFireSoundClip = null;
        [SerializeField] [Range(0, 1)] float fireSoundVolume = 0.5f;
        [SerializeField] float projectileDistance = 20f;
        [SerializeField] ParticleSystem muzzlerParticleSystemPrefab = null;
    }
}
