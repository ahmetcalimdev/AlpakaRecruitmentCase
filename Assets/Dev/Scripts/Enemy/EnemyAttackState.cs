public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        enemy.State = EnemyStateEnum.ATTACK;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (!enemy.IsWithinAttackingDistance)
        {
            if (enemy.IsAggroed)
            {
                enemy.StateMachine.ChangeState(enemy.ChaseState);
            }
            else
            {
                enemy.StateMachine.ChangeState(enemy.StateIdle);
            }
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }
}
