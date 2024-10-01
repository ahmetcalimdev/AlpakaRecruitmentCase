
using System;
using UnityEngine;

[Serializable]
public class LevelConfig
{
    [Header("Level Settings")]
    [Tooltip("Level Duration")]
    [SerializeField] private float levelDuration;

    [Tooltip("Wave Config")]
    [SerializeField] private WaveConfig waveConfig;


    public float LevelDuration => levelDuration;
    public WaveConfig WaveConfig => waveConfig;
}
