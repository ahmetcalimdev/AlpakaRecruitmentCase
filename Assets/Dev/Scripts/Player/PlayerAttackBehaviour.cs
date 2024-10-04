using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    [SerializeField]
    private Gun _gun;

    private bool isAttacking;
    private AnimationHandler _animationHandler;
    private void Start()
    {
        _animationHandler = GetComponent<AnimationHandler>();
    }
    public void StartAttacking() 
    {
        if (!GameManager.Instance.IsGameRunning) return;
        if (!isAttacking)
        {
            isAttacking = true;
            _animationHandler.EnableAttackingAnimation(true);
            _gun.StartShooting();
        }
    }
    public void StopAttacking() 
    {
        if (isAttacking)
        {
            isAttacking = false;

            _animationHandler.EnableAttackingAnimation(false);
            _gun.StopShooting();
        }
    }
}
