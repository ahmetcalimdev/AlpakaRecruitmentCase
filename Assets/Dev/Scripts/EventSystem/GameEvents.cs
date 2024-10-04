
using System;

public static class GameEvents
{
    public static event Action<int, float> OnLevelStarted;
    public static event Action<Enemy> OnEnemyDied;
    public static event Action<float> OnTimeTick;
    public static event Action<UpgradeConfig, int> OnUpgrade;
    public static event Action<int> OnMoneyEarned;
    public static event Action<Coin> OnCoinEarned;
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
    public static void TriggerMoneyEarned(int moneyEarned) 
    {
        OnMoneyEarned?.Invoke(moneyEarned);
    }
    public static void TriggerCoinEarned(Coin coin) 
    {
        OnCoinEarned?.Invoke(coin);
    }
}
