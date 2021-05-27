using System.Collections;
using TheSicker.Core;
using TheSicker.Projectile;
using UnityEngine;

namespace TheSicker.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        // config
        [Header("Object Pool Based")]
        [SerializeField] bool isProjectileBased = true;
        [SerializeField] ObjectPoolIds projectile = ObjectPoolIds.PlayerProjectile;
        [SerializeField] float projectileFiringPeriod = 0.1f;
        [SerializeField] AudioClip onFireSoundClip = null;
        [SerializeField] [Range(0, 1)] float fireSoundVolume = 0.5f;

        [Header("Custom Fire Based")]
        [SerializeField] ProjectileCustomFire projectileCustomFirePrefab = null;

        [Header("Shared")]
        [SerializeField] float projectileDistance = 20f;
        [SerializeField] ParticleSystem muzzlerParticleSystemPrefab = null;

        // properties
        public bool IsProjectileBased => isProjectileBased;
        public ObjectPoolIds Projectile => projectile;
        public float ProjectileFiringPeriod => projectileFiringPeriod;
        public AudioClip OnFireSoundClip => onFireSoundClip;
        public float FireSoundVolume => fireSoundVolume;
        public ProjectileCustomFire ProjectileCustomFirePrefab => projectileCustomFirePrefab;
        public float ProjectileDistance => projectileDistance;
        public ParticleSystem MuzzlerParticleSystemPrefab => muzzlerParticleSystemPrefab;

    }
}
