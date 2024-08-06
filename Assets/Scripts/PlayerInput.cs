using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Human playerCharacters;
    [SerializeField] private float requredHoldingTimeToFireBurst = 0.1f;
    private float timeOfHoldingShotButton;
    private bool ableToMakeFireBurstInput = true;

    private void Update()
    {
        Movement();
        Shooting();
    }

    private void Movement()
    {
        playerCharacters.Move(Input.GetAxisRaw("Horizontal"));
    }

    private void Shooting()
    {
        if (Input.GetMouseButton(0))
        {
            timeOfHoldingShotButton += Time.deltaTime;
        }

        if (ableToMakeFireBurstInput && timeOfHoldingShotButton > requredHoldingTimeToFireBurst)
        {
            playerCharacters.FireBurst();
            ableToMakeFireBurstInput = false;
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(timeOfHoldingShotButton <= requredHoldingTimeToFireBurst)
            {
                playerCharacters.ShootOnce();
            }

            ableToMakeFireBurstInput = true;
            timeOfHoldingShotButton = 0;
            return;
        }
    }
}
