using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public JoystickController joystick;
    private CharacterController characterController;
    public float moveSpeed = 5f;
    private readonly float gravity = -9.81f;
    private Vector3 velocity;
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
        if (!characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f;
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}
