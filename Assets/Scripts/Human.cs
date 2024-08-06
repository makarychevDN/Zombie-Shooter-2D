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
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private AudioSource pickUpAmmoSound;
    private ProjectilesPoolManager projectilesPoolManager;
    private float fireParticlesExistingTime = 0.05f;

    public UnityEvent OnAmmoEnded;
    public UnityEvent<int> OnAmmoUpdated;

    public int Ammo => ammo;

    public void ShootOnce()
    {
        if (ammo == 0)
        {
            OnAmmoEnded.Invoke();
            return;
        }

        var spawnedProjectile = projectilesPoolManager.GetProjectile();
        spawnedProjectile.transform.position = pointOfBulletSpawn.transform.position;
        spawnedProjectile.SetVelocity(pointOfBulletSpawn.right);

        Invoke(nameof(DisableFireParticles), fireParticlesExistingTime);
        fireParticles.SetActive(true);
        shootSound.Play();

        ammo--;
        OnAmmoUpdated.Invoke(ammo);
    }

    public void FireBurst()
    {
        for (int i = 0; i < amountOfBulletsInBurst; i++)
        {
            Invoke(nameof(ShootOnce), i * timeBetweenShotsInBurst);
        }
    }

    public void Init(ProjectilesPoolManager projectilesPoolManager)
    {
        this.projectilesPoolManager = projectilesPoolManager;
    }

    public void PickUpAmmo(int value)
    {
        ammo += value;
        pickUpAmmoSound.Play();
        OnAmmoUpdated.Invoke(ammo);
    }

    private void DisableFireParticles() => fireParticles.SetActive(false);
}
