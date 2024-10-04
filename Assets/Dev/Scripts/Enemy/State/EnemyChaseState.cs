
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private Transform _playerTransform;

    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        _playerTransform = FindObjectOfType<CharacterMovementController>().transform;
    }
    public override void Enter()
    {
        base.Enter();

        enemy.State = EnemyStateEnum.CHASE;
    }
    public override void Exit()
    {
        base.Exit();
        enemy.Stop();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();

        enemy.Move(_playerTransform.position);
        if (enemy.IsWithinAttackingDistance)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
        if (!enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.StateIdle);
        }
    }
}
