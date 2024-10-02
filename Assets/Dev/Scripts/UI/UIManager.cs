using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timeRemainingTxt;
    private void OnEnable()
    {
        GameEvents.OnTimeTick += UpdateTimeRemainingTxt;
    }

    private void UpdateTimeRemainingTxt(float remainingTime)
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        _timeRemainingTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
