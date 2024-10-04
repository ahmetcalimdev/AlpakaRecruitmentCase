using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerConfig playerConfig;
    public int baseUpgradeCost = 100;
    public float costMultiplier = 1.1f;
    private int currentUpgradeCost;

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

    private void Start()
    {
        LoadPlayerData();
        currentUpgradeCost = baseUpgradeCost;
    }

    public void BuyUpgrade(UpgradeConfig upgrade)
    {
        if (playerConfig.playerMoney >= currentUpgradeCost)
        {
            playerConfig.playerMoney -= currentUpgradeCost;
            playerConfig.AddUpgrade(upgrade);

            currentUpgradeCost = Mathf.RoundToInt(currentUpgradeCost * costMultiplier);

            SavePlayerData();
        }
    }

    private void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerConfig"))
        {
            string jsonData = PlayerPrefs.GetString("PlayerConfig");
            playerConfig = JsonUtility.FromJson<PlayerConfig>(jsonData);
        }
        else
        {
            playerConfig = new PlayerConfig();
            playerConfig.playerMoney = 500;
        }
    }

    private void SavePlayerData()
    {
        string jsonData = JsonUtility.ToJson(playerConfig);
        PlayerPrefs.SetString("PlayerConfig", jsonData);
    }
    private void OnApplicationQuit()
    {
        SavePlayerData();
    }
}
