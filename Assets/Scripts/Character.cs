using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int hp;

    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private Transform pointOfBulletSpawn;
    [SerializeField] private int amountOfBulletsInBurst;
    [SerializeField] private float timeBetweenShotsInBurst;

    public UnityEvent OnApplyDamage;
    public UnityEvent OnHPEnded;

    public void Move(float inputX)
    {
        rb.velocity = new Vector2 (inputX * speed, 0);
    }

    public void ApplyDamage(int damageValue)
    {
        hp -= damageValue;

        if(hp <= 0) 
        {
            OnHPEnded.Invoke();
            Destroy(gameObject);
        }
    }

    public void ShootOnce()
    {
        var spawnedBullet = Instantiate(bulletPrefab, pointOfBulletSpawn.transform.position, Quaternion.identity);
        spawnedBullet.SetVelocity();
    }

    public void FireBurst()
    {
        for(int i = 0; i < amountOfBulletsInBurst; i++)
        {
            Invoke(nameof(ShootOnce), i * timeBetweenShotsInBurst);
        }
    }
}
