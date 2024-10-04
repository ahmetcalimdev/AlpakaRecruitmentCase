using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    private Player _player;
    private readonly float gravity = -9.81f;
    public JoystickController joystick;
    private CharacterController characterController;
    public float moveSpeed = 5f;
    [HideInInspector]
    private Vector3 _velocity;
    
    private void Start()
    {
        _player = GetComponent<Player>();
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsGameRunning) return;
        if (!joystick.IsJoystickActive) return;
        Movement();
    }

    private void Movement()
    {
        if(_player.ClosestEnemy)
            transform.forward = _player.ClosestEnemy.transform.position - transform.position;


        if (!joystick.IsJoystickActive) return;
        float horizontal = joystick.Horizontal();
        float vertical = joystick.Vertical();

        Vector3 move = new Vector3(horizontal, 0, vertical);

        if (move.magnitude > 1)
        {
            move = move.normalized;
        }
        characterController.Move(move * moveSpeed * Time.deltaTime);
       
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
