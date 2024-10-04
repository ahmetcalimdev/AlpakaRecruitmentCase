using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroCheck : MonoBehaviour
{
    public GameObject PlayerTarget {  get; private set; }
    private Enemy _enemy;
    private void Awake()
    {
        PlayerTarget = FindObjectOfType<CharacterMovementController>().gameObject;
        _enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.IsGameRunning) return;
        if (other.gameObject == PlayerTarget)
        {
            _enemy.SetAggroStatus(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerTarget)
        {
            _enemy.SetAggroStatus(false);
        }
    }
}
