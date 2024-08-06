using UnityEngine;

public class Zombie : Character
{
    [SerializeField] private AmmoBox ammoPrefab;

    private int touchDamage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<Human>();

        if (target != null)
        {
            target.ApplyDamage(touchDamage);
        }
    }

    private void Awake()
    {
        OnHpEnded.AddListener(DropAmmo);
    }

    private void DropAmmo()
    {
        Instantiate(ammoPrefab, transform.position, Quaternion.identity);
    }
}
