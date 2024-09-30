using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    private readonly float gravity = -9.81f;
    public JoystickController joystick;
    private CharacterController characterController;
    public float moveSpeed = 5f;
    [HideInInspector]
    private Vector3 _velocity;
    
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        float horizontal = joystick.Horizontal();
        float vertical = joystick.Vertical();

        Vector3 move = new Vector3(horizontal, 0, vertical);

        if (move.magnitude > 1)
        {
            move = move.normalized;
        }
        characterController.Move(move * moveSpeed * Time.deltaTime);
        transform.forward = move;
        if (!characterController.isGrounded)
        {
            _velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            _velocity.y = 0f;
        }
        characterController.Move(_velocity * Time.deltaTime);
    }
}
