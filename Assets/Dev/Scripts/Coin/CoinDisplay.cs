using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _coinTxt;
    private int currentCoin;
    private void Start()
    {
        UpdateTxt();
    }
    private void OnEnable()
    {
        GameEvents.OnCoinEarned += OnCoinEarned;
    }

    private void OnDisable()
    {
        GameEvents.OnCoinEarned -= OnCoinEarned;
    }

    private void OnCoinEarned(Coin coin)
    {
        currentCoin += coin.coinAmount;
        UpdateTxt();
    }

    private void UpdateTxt()
    {
        currentCoin = GameManager.Instance.playerConfig.playerMoney;
        _coinTxt.text = currentCoin.ToString();
    }
}
