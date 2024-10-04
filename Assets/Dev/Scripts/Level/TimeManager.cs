using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _remainingTime;
    private bool _isCounting;
    private void OnEnable()
    {
        GameEvents.OnLevelStarted += StartTimer;
    }

    private void OnDisable()
    {
        GameEvents.OnLevelStarted -= StartTimer;
    }

    public void StartTimer(int levelIndex, float duration)
    {
        GameManager.Instance.IsGameRunning = true;
        StartTime(duration);
    }

    public void StartTime(float time)
    {
        _remainingTime = time;
        _isCounting = true;
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (_remainingTime > 0 && _isCounting && GameManager.Instance.IsGameRunning)
        {
            yield return new WaitForSeconds(1f);
            _remainingTime--;
            GameEvents.TriggerOnTimeTick(_remainingTime);

            if (_remainingTime <= 0)
            {
                _isCounting = false;
                GameEvents.TriggerOnTimeFinished();
            }
        }
    }

    public void StopTimer()
    {
        _isCounting = false;
        StopCoroutine(TimerCoroutine());
    }
}
