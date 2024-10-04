using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public float MaxHealth { get; set; } = 1000f;
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
        GameManager.Instance.IsGameRunning = true;  
    }
    private void OnEnable()
    {
        GameEvents.OnEnemyDied += OnEnemyDied;
        GameEvents.OnEnemyAttack += OnEnemyAttack;
    }

    private void OnEnemyAttack(float dmg)
    {   
        Damage(dmg);
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyDied -= OnEnemyDied;
        GameEvents.OnEnemyAttack -= OnEnemyAttack;
    }
    private void OnEnemyDied(Enemy enemy)
    {
        if (targets.Count == 0) return;
        ClosestEnemy = targets.OrderBy(t => Vector3.Distance(t.transform.position, transform.position)).First();
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
            Die();
    }

    public void Die()
    {
        GameEvents.TriggerOnPlayerDied();
    }
    
    public void SetTarget(List<Enemy> enemies)
    {
        targets = enemies;
        if (targets.Count > 0)
        {
            attackBehaviour.StartAttacking();
            foreach (var item in targets)
            {
                item.EnableTargetDisplay(false);
            }
            Enemy[] aliveEnemies = targets.Where(t=>!t.IsDead).ToArray();
            if (aliveEnemies.Length == 0)
                return;

            ClosestEnemy = aliveEnemies.OrderBy(t => Vector3.Distance(t.transform.position, transform.position)).First();
            ClosestEnemy.EnableTargetDisplay(true);
        }
        else
        {
            attackBehaviour.StopAttacking();
        }
       
    }

}
