using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDistanceCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; private set; }
    private Enemy _enemy;
    private void Awake()
    {
        PlayerTarget = FindObjectOfType<CharacterMovementController>().gameObject;
        _enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerTarget)
        {
            _enemy.SetAttackingDistance(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerTarget)
        {
            _enemy.SetAttackingDistance(false);
        }
    }
}
