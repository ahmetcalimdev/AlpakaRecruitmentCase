using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private LevelConfig _levelConfig;
    public LevelConfig LevelConfig => _levelConfig;
}
