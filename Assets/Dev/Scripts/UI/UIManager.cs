using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timeRemainingTxt;
    [SerializeField]
    private Button gameoverContinueButton;
    [SerializeField]
    private Button completedContinueButton;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject completedPanel;
    [SerializeField]
    private Image healthBar;
    private float currentHealth;
    private void Start()
    {
        currentHealth = GameManager.Instance.playerConfig.maxPlayerHealth;
    }
    private void OnEnable()
    {
        GameEvents.OnTimeTick += UpdateTimeRemainingTxt;
        gameoverContinueButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        completedContinueButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        GameEvents.OnPlayerDied += OnPlayerDied;
        GameEvents.OnEnemyAttack += OnEnemyAttack;
        GameEvents.OnTimeFinished += OnTimeFinished;
    }

    private void OnTimeFinished()
    {
        completedPanel.SetActive(true);
    }

    private void OnEnemyAttack(float obj)
    {
        currentHealth -= obj;
        healthBar.fillAmount = currentHealth / GameManager.Instance.playerConfig.maxPlayerHealth;
    }

    private void OnPlayerDied()
    {
        gameOverPanel.SetActive(true);
    }

    private void OnDisable()
    {
        GameEvents.OnTimeTick -= UpdateTimeRemainingTxt;
        gameoverContinueButton.onClick.RemoveAllListeners();
        completedContinueButton.onClick.RemoveAllListeners();
        GameEvents.OnPlayerDied -= OnPlayerDied;
        GameEvents.OnEnemyAttack -= OnEnemyAttack;
        GameEvents.OnTimeFinished -= OnTimeFinished;
    }

    private void UpdateTimeRemainingTxt(float remainingTime)
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        _timeRemainingTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
