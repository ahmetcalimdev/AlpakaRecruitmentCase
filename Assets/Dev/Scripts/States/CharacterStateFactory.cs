
public class CharacterStateFactory
{
    CharacterStateMachine _context;
    public CharacterStateFactory(CharacterStateMachine context)
    {
        _context = context;
    }
    public CharacterBaseState Idle() 
    {
        return new IdleState(_context, this);
    }
    public CharacterBaseState Walk() 
    {
        return new WalkingState(_context, this);
    }
    public CharacterBaseState Run() 
    {
        return new RunningState(_context, this);
    }
    public CharacterBaseState Attack() 
    {
        return new AttackingState(_context, this);
    }
    public CharacterBaseState Die() 
    {
        return new DyingState(_context, this);
    }
}
