using UnityEngine;
using UnityEngine.Events;

public class Human : Character
{
    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private Transform pointOfBulletSpawn;
    [SerializeField] private int amountOfBulletsInBurst;
    [SerializeField] private float timeBetweenShotsInBurst;
    [SerializeField] private GameObject fireParticles;
    [SerializeField] private int ammo = 20;
    private float fireParticlesExistingTime = 0.05f;

    public UnityEvent OnAmmoEnded;

    public void ShootOnce()
    {
        fireParticles.SetActive(true);
        Invoke(nameof(DisableFireParticles), fireParticlesExistingTime);
        var spawnedBullet = Instantiate(bulletPrefab, pointOfBulletSpawn.transform.position, Quaternion.identity);
        spawnedBullet.SetVelocity();
        ammo--;

        if (ammo == 0)
            OnAmmoEnded.Invoke();
    }

    public void FireBurst()
    {
        for (int i = 0; i < amountOfBulletsInBurst; i++)
        {
            Invoke(nameof(ShootOnce), i * timeBetweenShotsInBurst);
        }
    }

    private void DisableFireParticles() => fireParticles.SetActive(false);
}
