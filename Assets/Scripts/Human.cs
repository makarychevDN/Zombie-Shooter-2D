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
    public UnityEvent<int> OnAmmoUpdated;

    public int Ammo => ammo;

    public void ShootOnce()
    {
        fireParticles.SetActive(true);
        Invoke(nameof(DisableFireParticles), fireParticlesExistingTime);
        var spawnedBullet = Instantiate(bulletPrefab, pointOfBulletSpawn.transform.position, Quaternion.identity);
        spawnedBullet.SetVelocity(pointOfBulletSpawn.right);

        ammo--;
        OnAmmoUpdated.Invoke(ammo);

        if (ammo == 0)
        {
            OnAmmoEnded.Invoke();
        }
    }

    public void FireBurst()
    {
        for (int i = 0; i < amountOfBulletsInBurst; i++)
        {
            Invoke(nameof(ShootOnce), i * timeBetweenShotsInBurst);
        }
    }

    public void PickUpAmmo(int value)
    {
        ammo += value;
        OnAmmoUpdated.Invoke(ammo);
    }

    private void DisableFireParticles() => fireParticles.SetActive(false);
}
