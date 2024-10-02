using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public float attackDamage { get; set; } = 5f;
    public bool IsDead { get; set; }

    private PlayerAttackBehaviour attackBehaviour;
    private List<Enemy> targets;
    public Enemy ClosestEnemy { get; set; }
    private void Start()
    {
        attackBehaviour = GetComponent<PlayerAttackBehaviour>();
        CurrentHealth = MaxHealth;
    }
    private void OnEnable()
    {
        GameEvents.OnEnemyDied += OnEnemyDied;
    }
    private void OnDisable()
    {
        GameEvents.OnEnemyDied -= OnEnemyDied;
    }
    private void OnEnemyDied(Enemy enemy)
    {
        if (targets.Count == 0) return;
        ClosestEnemy = targets.OrderBy(t => Vector3.Distance(t.transform.position, transform.position)).First();

        Debug.Log("Update closest enemy");
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
            Die();
    }

    public void Die()
    {

    }

    public void Attack()
    {

    }
    
    public void SetTarget(List<Enemy> enemies)
    {
        targets = enemies;
        if (targets.Count > 0)
        {
            attackBehaviour.StartAttacking();
            ClosestEnemy = targets.OrderBy(t => Vector3.Distance(t.transform.position, transform.position)).First();
        }
        else
        {
            attackBehaviour.StopAttacking();
        }
       
    }

}
