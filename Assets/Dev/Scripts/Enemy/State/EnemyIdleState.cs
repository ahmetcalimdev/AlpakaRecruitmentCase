
using UnityEngine;
using UnityEngine.AI;

public class EnemyIdleState : EnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;
    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        enemy.State = EnemyStateEnum.IDLE;
        SetRandomPatrol();
    }

    private void SetRandomPatrol()
    {
        Debug.Log("Set Random Patrol");
        _targetPos = GetRandomPointOnNavmesh();
        enemy.Move(_targetPos);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }
        if (enemy.IsWithinAttackingDistance)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
        if (enemy.NavMeshAgent.remainingDistance <= .1f)
        {
            SetRandomPatrol();
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
    private Vector3 GetRandomPointOnNavmesh() 
    {
        return NavMeshRandomPositionGenerator.RandomNavmeshLocation(enemy.transform.position, 5f);
    }
    
}
