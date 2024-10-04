using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private CoinPool pool;
    private void Awake()
    {
        pool = GetComponentInChildren<CoinPool>();
    }
    private void OnEnable()
    {
        GameEvents.OnEnemyDied += OnEnemyDied;
    }
    private void OnDisable()
    {
        GameEvents.OnEnemyDied -= OnEnemyDied;
    }
    private void OnEnemyDied(Enemy enemy)
    {
        SpawnCoin(enemy.transform.position + new Vector3(0f, .5f, 0f));
    }

    public void SpawnCoin(Vector3 pos) 
    {
        Coin coin = pool.Dequeue();
        coin.transform.position = pos;
    }
}
