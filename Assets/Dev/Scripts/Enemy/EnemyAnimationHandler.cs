using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage() 
    {
        animator.SetTrigger("TakeDamage");
    }
    public void Die() 
    {
        animator.SetTrigger("Die");
    }

    internal void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
