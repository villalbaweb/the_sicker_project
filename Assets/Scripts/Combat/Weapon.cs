using UnityEngine;

namespace TheSicker.Projectile
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        // config
        [Header("Object Pool")]
        [SerializeField] string projectile;

        [Header("Control")]
        [SerializeField] float projectileFiringPeriod = 0.1f;
        [SerializeField] float projectileDistance = 20f;

        [Header("VFX")]
        [SerializeField] ParticleSystem muzzlerVFX = null;

        [Header("SFX")]
        [SerializeField] AudioClip onFireSoundClip = null;
        [SerializeField] [Range(0, 1)] float fireSoundVolume = 0.5f;

        // properties
        public string Projectile => projectile;
        public float ProjectileFiringPeriod => projectileFiringPeriod;
        public float ProjectileDistance => projectileDistance;
        public ParticleSystem MuzzlerVFX => muzzlerVFX;
        public AudioClip OnFireSoundClip => onFireSoundClip;
        public float FireSoundVolume => fireSoundVolume;
    }
}
