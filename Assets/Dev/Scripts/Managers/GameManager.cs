using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerConfig playerConfig;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        GameEvents.OnUpgrade += OnUpgrade;
        GameEvents.OnCoinEarned += OnCoinEarned;
    }

    private void OnCoinEarned(Coin coin)
    {
        AddMoney(coin.coinAmount);
    }

    private void OnDisable()
    {
        GameEvents.OnUpgrade -= OnUpgrade;
        GameEvents.OnCoinEarned -= OnCoinEarned;
    }

    private void OnUpgrade(UpgradeConfig config, int arg2)
    {
        SpentMoney(arg2);
    }

    public void SpentMoney(int money) 
    {
        playerConfig.playerMoney -= money;
    }
    public void AddMoney(int addAmount) 
    {
        playerConfig.playerMoney += addAmount;
    }
}
