public abstract class CharacterBaseState
{
    protected CharacterStateMachine _context;
    protected CharacterStateFactory _factory;
    public CharacterBaseState(CharacterStateMachine context, CharacterStateFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
    public abstract void CheckSwitchStates();
    void UpdateStates() { }
    protected void SwitchState(CharacterBaseState newState) 
    {
        Exit();
        newState.Enter();
        _context.CurrentState = newState;
    }

    
}
