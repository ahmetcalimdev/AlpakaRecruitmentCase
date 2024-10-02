
using System;

public static class GameEvents
{
    public static event Action<int, float> OnLevelStarted;
    public static event Action<Enemy> OnEnemyDied;
    public static event Action<float> OnTimeTick;
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

}
