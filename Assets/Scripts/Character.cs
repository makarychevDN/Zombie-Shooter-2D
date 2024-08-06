using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int hp;
    [SerializeField] private Projectile bulletPrefab;

    public void Move(float inputX)
    {
        rb.velocity = new Vector2 (inputX * speed, 0);
    }

    public void ApplyDamage(int damageValue)
    {
        hp -= damageValue;
    }

    public void Shot()
    {
        var spawnedBullet = Instantiate(bulletPrefab);
        spawnedBullet.SetVelocity();
    }
}
