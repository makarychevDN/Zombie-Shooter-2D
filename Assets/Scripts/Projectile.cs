using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int speed;
    [SerializeField] private Rigidbody2D rb;
    private ProjectilesPoolManager poolManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<Character>();

        if (target != null)
        {
            target.ApplyDamage(damage);
        }

        poolManager.ReleaseProjectile(this);
    }

    public void SetVelocity(Vector3 directionOfMovement)
    {
        rb.velocity = directionOfMovement * speed;
    }

    public void SetPoolManager(ProjectilesPoolManager poolManager) 
    {
        this.poolManager = poolManager;
    }
}
