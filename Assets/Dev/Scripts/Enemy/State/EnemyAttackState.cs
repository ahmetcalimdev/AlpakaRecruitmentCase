using System.Collections;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private float nextActionTime = 0.0f;
    private float period = 3.0f;

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
        if (Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime += period;
            enemy.Attack();
        }
     

    }
}
