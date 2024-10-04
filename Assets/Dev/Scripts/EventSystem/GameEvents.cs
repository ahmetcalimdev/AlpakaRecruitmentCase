
using System;

public static class GameEvents
{
    public static event Action<int, float> OnLevelStarted;
    public static event Action<Enemy> OnEnemyDied;
    public static event Action<float> OnTimeTick;
    public static event Action<UpgradeConfig, int> OnUpgrade;
    public static event Action<Coin> OnCoinEarned;
    public static event Action<float> OnEnemyAttack;
    public static event Action OnPlayerDied;
    public static event Action OnTimeFinished;
    public static void TriggerOnLevelStarted(int level, float duration) 
    {
        OnLevelStarted?.Invoke(level, duration);
    }
    public static void TriggerOnEnemyDied(Enemy enemy) 
    {
        OnEnemyDied?.Invoke(enemy);
    }
    public static void TriggerOnTimeTick(float time)
    {
        OnTimeTick?.Invoke(time);
    }
    public static void TriggerOnUpgrade(UpgradeConfig upgradeConfig, int cost) 
    {
        OnUpgrade?.Invoke(upgradeConfig, cost);
    }

    public static void TriggerCoinEarned(Coin coin) 
    {
        OnCoinEarned?.Invoke(coin);
    }
    public static void TriggerOnEnemyAttack(float damage) 
    {
        OnEnemyAttack?.Invoke(damage);
    }
    public static void TriggerOnPlayerDied() 
    {
        OnPlayerDied?.Invoke();
    }
    public static void TriggerOnTimeFinished() 
    {
        OnTimeFinished?.Invoke();
    }
}
