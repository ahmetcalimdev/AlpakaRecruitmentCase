using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance {  get; private set; }
    public List<UpgradeConfig> Upgrades;
    public GeneralUpgradeConfig generalUpgradeConfig;
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
    public void Upgrade(UpgradeButton upgradeButton) 
    {
        GameEvents.TriggerOnUpgrade(upgradeButton.config);
    }
    public int GetUpgradeLevel(UpgradeType upgradeType)
    {
        UpgradeConfig upgradeConfig = Upgrades.Where(t=>t.UpgradeType == upgradeType).First();
        return upgradeConfig.upgradeLevel;
    }
}
public enum UpgradeType 
{
    GunAttackRange,
    GunAttackSpeed,
    GunAttackRate,
    AuraAttackRange,
    AuraDamage,
    AuraRate
}
