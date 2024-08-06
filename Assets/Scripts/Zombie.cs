using UnityEngine;

public class Zombie : Character
{
    private int touchDamage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<Human>();

        if (target != null)
        {
            target.ApplyDamage(touchDamage);
        }
    }
}
