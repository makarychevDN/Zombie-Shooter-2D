using UnityEngine;

public class Human : Character
{
    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private Transform pointOfBulletSpawn;
    [SerializeField] private int amountOfBulletsInBurst;
    [SerializeField] private float timeBetweenShotsInBurst;

    public void ShootOnce()
    {
        var spawnedBullet = Instantiate(bulletPrefab, pointOfBulletSpawn.transform.position, Quaternion.identity);
        spawnedBullet.SetVelocity();
    }

    public void FireBurst()
    {
        for (int i = 0; i < amountOfBulletsInBurst; i++)
        {
            Invoke(nameof(ShootOnce), i * timeBetweenShotsInBurst);
        }
    }
}
