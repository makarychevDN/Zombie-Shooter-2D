using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int hp;
    [SerializeField] protected Transform sprite;
    [SerializeField] protected Animator animator;

    public UnityEvent<int> OnHealthDecreased;
    public UnityEvent OnHPEnded;


    public int Hp => hp;

    public virtual void Move(float inputX)
    {
        rb.velocity = new Vector2(inputX * speed, 0);

        if (inputX == 0)
        {
            animator.SetTrigger("stay");
            return;
        }

        sprite.rotation = Quaternion.Euler(0, inputX < 0 ? 180 : 0, 0);
        animator.SetTrigger("run");
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
