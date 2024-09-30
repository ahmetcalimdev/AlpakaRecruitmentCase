using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    CharacterBaseState _currentState;
    public CharacterBaseState CurrentState {  get { return _currentState; } set { _currentState = value; } }
    CharacterStateFactory _characterStateFactory;
    private void Start()
    {
        _characterStateFactory = new CharacterStateFactory(this);
        _currentState = _characterStateFactory.Idle();
        CurrentState.Enter();
    }
    private void FixedUpdate()
    {
        CurrentState.Update();
    }
    public void ChangeState(CharacterBaseState characterBaseState) 
    {
        _currentState = characterBaseState;
        characterBaseState.Enter();
    }
}
