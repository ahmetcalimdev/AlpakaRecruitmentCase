using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;
    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine) 
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void FrameUpdate(){}

}
