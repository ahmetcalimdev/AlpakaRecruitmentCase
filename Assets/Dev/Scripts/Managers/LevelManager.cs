using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("Level Configuration")]
    public List<Level> levels = new List<Level>();
    public Level CurrentLevel { get; private set; }
    private int currentLevelIndex = 0;
    private const string LevelKey = "CurrentLevel";

    [Header("Spawner Configuration")]
    [SerializeField] private EnemySpawner enemySpawner;

    private void Start()
    {
        if (CurrentLevel == null && levels.Count > 0)
        {
            LoadCurrentLevel();
        }
    }
    private void LoadCurrentLevel()
    {
        if (currentLevelIndex >= 0 && currentLevelIndex < levels.Count)
        {
            CurrentLevel = levels[currentLevelIndex];
        }
        StartLevel();
    }
    public void SaveLevelProgress()
    {
        PlayerPrefs.SetInt(LevelKey, currentLevelIndex);
        PlayerPrefs.Save();
    }
    private void LoadLevelProgress()
    {
        if (PlayerPrefs.HasKey(LevelKey))
        {
            currentLevelIndex = PlayerPrefs.GetInt(LevelKey);
        }
        else
        {
            currentLevelIndex = 0;
        }
    }
    public void LoadNextLevel()
    {
        if (currentLevelIndex + 1 < levels.Count)
        {
            EndLevel();

            currentLevelIndex++;
            LoadCurrentLevel();
            SaveLevelProgress();

            StartLevel();
        }
    }
    public void LoadLevelByIndex(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levels.Count)
        {
            EndLevel();

            currentLevelIndex = levelIndex;
            LoadCurrentLevel();
            SaveLevelProgress();

            StartLevel();
        }
    }
    public void StartLevel()
    {
        if (enemySpawner != null && CurrentLevel != null)
        {
            GameEvents.TriggerOnLevelStarted(currentLevelIndex, CurrentLevel.LevelConfig.LevelDuration);
            enemySpawner.StartSpawning(CurrentLevel.LevelConfig.WaveConfig);
        }
    }
    public void EndLevel()
    {
        if (enemySpawner != null)
        {
            enemySpawner.StopSpawning();
        }
    }
}
