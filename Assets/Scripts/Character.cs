using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    public void Move(float inputX)
    {
        rb.velocity = new Vector2 (inputX * speed, 0);
    }
}
