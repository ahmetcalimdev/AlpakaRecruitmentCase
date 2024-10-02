using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, IDistanceCheckable, IPoolableObject<Enemy>
{
    public EnemyStateEnum State;
    public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState StateIdle { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public NavMeshAgent NavMeshAgent { get; set; }
    public bool IsAggroed { get; set; }
    public bool IsWithinAttackingDistance { get; set; }
    public IObjectPool<Enemy> PoolParent { get; set; }
    public bool IsDead { get; set; }

    public float RandomMovementRange = 5f;
    [SerializeField]
    private ParticleSystem _hitParticle;
    [SerializeField]
    private ParticleSystem _deadParticle;
    
    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        StateIdle = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        IsDead = false;
        _hitParticle.transform.parent = null;
        _deadParticle.transform.parent = null;
        CurrentHealth = MaxHealth;
        SetAggroStatus(false);
        SetAttackingDistance(false);
        StateMachine.Initialize(StateIdle);
    }
    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void Damage(float damageAmount)
    {   
        if (IsDead) return;
        _hitParticle.transform.position = transform.position;
        _hitParticle.Play();
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
            Die();
    }

    public void Die()
    {
        IsDead = true;
        _deadParticle.transform.position = transform.position;
        _deadParticle.Play();
        GameEvents.TriggerOnEnemyDied(this);
        PoolParent.Enqueue(this);
    }

    public void Move(Vector3 destination)
    {
        NavMeshAgent.isStopped = false;
        NavMeshAgent.SetDestination(destination);
    }

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetAttackingDistance(bool isWithinAttackingDistance)
    {
        IsWithinAttackingDistance = isWithinAttackingDistance;
    }

    public void Stop()
    {
        NavMeshAgent.isStopped = true;
    }

}
public enum EnemyStateEnum
{
    IDLE,
    CHASE,
    ATTACK
}
