using UnityEngine;


public class AnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private CharacterMovementController _characterMovementController;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterMovementController = GetComponent<CharacterMovementController>();
    }
    private void FixedUpdate()
    {
        Vector2 input = new Vector2(_characterMovementController.joystick.Horizontal(), _characterMovementController.joystick.Vertical());
        _animator.SetFloat("Velocity", input.sqrMagnitude);
    }
    public void EnableAttackingAnimation(bool enabled) 
    {

    }
}
