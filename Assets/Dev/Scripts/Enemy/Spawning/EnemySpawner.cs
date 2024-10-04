using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemyPool _enemyPool;
    private WaveConfig _waveConfig;

    private float _spawnInterval;
    private Coroutine _spawningCoroutine;
    private Transform _playerTransform;
    private void Awake()
    {
        _enemyPool = GetComponentInChildren<EnemyPool>();
    }
    private void SpawnEnemy(Vector3 spawnPosition)
    {
        Enemy spawnedEnemy = _enemyPool.Dequeue();
        spawnedEnemy.transform.position = spawnPosition;
    }
    public void StartSpawning(WaveConfig waveConfig)
    {
        if(_playerTransform == null)
            _playerTransform = FindObjectOfType<CharacterMovementController>().transform;

        _waveConfig = waveConfig;
        _spawnInterval = 60f / _waveConfig.EnemiesPerMinute;
        _spawningCoroutine = StartCoroutine(SpawnEnemiesRoutine());
    }
    public void StopSpawning()
    {
        if (_spawningCoroutine != null)
        {
            StopCoroutine(_spawningCoroutine);
            _spawningCoroutine = null;
        }
    }
    private IEnumerator SpawnEnemiesRoutine()
    {
        do
        {
            foreach (Enemy enemyType in _waveConfig.EnemyTypes)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();

                SpawnEnemy(spawnPosition);

                yield return new WaitForSeconds(_spawnInterval);
            }

        } while (_waveConfig.IsLoopingWave);

        StopSpawning();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return NavMeshRandomPositionGenerator.RandomNavmeshLocation(_playerTransform.position, 10f);
    }
}
