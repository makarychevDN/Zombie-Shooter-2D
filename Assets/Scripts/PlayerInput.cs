using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Character character;

    private void Update()
    {
        character.Move(Input.GetAxis("Horizontal"));
    }
}
