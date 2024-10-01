using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveConfig", menuName = "Wave System/Wave Config")]
public class WaveConfig : ScriptableObject
{
    [Header("Wave Settings")]
    [Tooltip("How many enemies will spawn per minute.")]
    [SerializeField] private int enemiesPerMinute;

    [Tooltip("Types of enemies that will spawn in this wave.")]
    [SerializeField] private List<Enemy> enemyTypes;

    [Tooltip("Should the wave loop when finished.")]
    [SerializeField] private bool isLoopingWave;

    public int EnemiesPerMinute => enemiesPerMinute;
    public List<Enemy> EnemyTypes => enemyTypes;
    public bool IsLoopingWave => isLoopingWave;
}