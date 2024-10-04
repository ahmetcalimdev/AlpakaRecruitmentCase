using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDistanceCheck : MonoBehaviour
{
    private Player _player;
    private List<Enemy> enemies = new List<Enemy>();
    private float distance = 8f;
    private int attackRangeUpgradeLevel = 1;
    private float baseAttackRange = 8f;
    private float rangeMultiplier = 1.2f;

   
    private void Start()
    {
        attackRangeUpgradeLevel = UpgradeManager.Instance.GetUpgradeLevel(UpgradeType.GunAttackRange);
        transform.localScale = new Vector3(GetCurrentAttackRange(), transform.localScale.y, GetCurrentAttackRange());
    }
    private void Awake()
    {
        _player = GetComponentInParent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (!enemies.Contains(enemy))
            {
                enemies.Add(enemy);
            }
            _player.SetTarget(enemies);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemies.Contains(enemy)) 
            {
                enemies.Remove(enemy);
            }
            _player.SetTarget(enemies);
        }
    }
    public float GetCurrentAttackRange()
    {
        return baseAttackRange * Mathf.Pow(rangeMultiplier, attackRangeUpgradeLevel - 1);
    }
}
