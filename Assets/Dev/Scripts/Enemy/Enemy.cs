using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, IDistanceCheckable, IPoolableObject<Enemy>
{
    public EnemyStateEnum State;
    public float MaxHealth { get; set; } = 500f;
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
    [SerializeField]
    private GameObject _targetDisplay;
    private EnemyAnimationHandler _animationHandler;
    private float _damage = 20f;
    private void Awake()
    {
        _animationHandler = GetComponent<EnemyAnimationHandler>();
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
        EnableTargetDisplay(false);
        StateMachine.Initialize(StateIdle);
        GameEvents.OnPlayerDied += OnPlayerDied;
    }
    private void OnDisable()
    {
        GameEvents.OnPlayerDied -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        Stop();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsGameRunning) return;
        StateMachine.CurrentEnemyState.FrameUpdate();
    }
    public void Damage(float damageAmount)
    {   
        if (IsDead) return;
        _animationHandler.TakeDamage();
        _hitParticle.transform.position = transform.position;
        _hitParticle.Play();
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
            Die();
    }

    public void Die()
    {
        Stop();
        IsDead = true;
        _targetDisplay.SetActive(false);
        _animationHandler.Die();
        StartCoroutine(DoDeadActions());
    }
    IEnumerator DoDeadActions() 
    {
        yield return new WaitForSeconds(2f);
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
    public void EnableTargetDisplay(bool enabled) 
    {
        _targetDisplay.SetActive(enabled);
    }
    public void Attack() 
    {
        GameEvents.TriggerOnEnemyAttack(_damage);
        _animationHandler.Attack();
    }

}
public enum EnemyStateEnum
{
    IDLE,
    CHASE,
    ATTACK
}
