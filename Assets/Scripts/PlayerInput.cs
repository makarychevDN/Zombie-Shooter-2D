using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Character character;

    private void Update()
    {
        character.Move(Input.GetAxisRaw("Horizontal"));

        if (Input.GetMouseButtonDown(0))
        {
            character.Shot();
        }
    }
}
