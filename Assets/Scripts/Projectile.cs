using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int speed;
    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<Character>();

        if (target != null)
        {
            target.ApplyDamage(damage);
        }

        Destroy(gameObject);
    }

    public void SetVelocity(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }
}
