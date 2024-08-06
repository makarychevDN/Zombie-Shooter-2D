using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectilesPoolManager : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    private Stack<Projectile> projectiles = new();

    public Projectile GetProjectile()
    {
        var freeProjectile = projectiles.FirstOrDefault(projectile => !projectile.gameObject.activeSelf);

        if (freeProjectile == null)
        {
            freeProjectile = Instantiate(projectilePrefab);
            projectiles.Push(freeProjectile);
            freeProjectile.SetPoolManager(this);
        }

        freeProjectile.gameObject.SetActive(true);
        return freeProjectile;
    }

    public void ReleaseProjectile(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }
}
