using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int hp;

    public UnityEvent<int> OnHealthDecreased;
    public UnityEvent OnHPEnded;


    public int Hp => hp;

    public void Move(float inputX)
    {
        rb.velocity = new Vector2 (inputX * speed, 0);
    }

    public void ApplyDamage(int damageValue)
    {
        hp -= damageValue;
        OnHealthDecreased.Invoke(hp);

        if(hp <= 0) 
        {
            OnHPEnded.Invoke();
            Destroy(gameObject);
        }
    }
}
