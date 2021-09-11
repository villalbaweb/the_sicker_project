namespace TheSicker.Core
{
    public enum ObjectPoolIds
    {
        // Attackers / Projectiles
        FollowOnDistanceAttacker,
        PlayerProjectile,
        FollowOnDistanceSmallAttacker,
        PlayerGreenProjectile,

        None,

        // Enemies
        FollowOnDistanceExplosive,
        OrangeSpaceship,
        EnemyBlueProjectile,
        CapsuleSpaceship,

        // Pickups
        ElectricityWeaponPickup,
        LaserWeaponPickup,
        GreenLaserWeaponPickup,
        FastFireballWeaponPickup,
        HealthObjectPickup,

        // Vfx
        LazerRayHitEffect,
        Explosion,
        EnemyCellExplosion,
        SmallEnemyCellExplosion
    }
}