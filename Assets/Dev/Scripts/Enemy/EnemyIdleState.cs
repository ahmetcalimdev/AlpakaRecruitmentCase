
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
        return RandomNavmeshLocation(5f);
    }
    private Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += enemy.transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
