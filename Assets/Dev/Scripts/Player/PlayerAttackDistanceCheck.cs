using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDistanceCheck : MonoBehaviour
{
    private Player _player;
    private List<Enemy> enemies = new List<Enemy>();
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
}
