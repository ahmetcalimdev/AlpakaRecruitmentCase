using System;
using System.Collections.Generic;

[Serializable]
public class PlayerConfig
{
    public int playerMoney;
    public List<UpgradeConfig> playerUpgrades;

    public PlayerConfig()
    {
        playerMoney = 0;
        playerUpgrades = new List<UpgradeConfig>();
    }

    public void AddUpgrade(UpgradeConfig upgrade)
    {
        var existingUpgrade = playerUpgrades.Find(u => u.UpgradeType == upgrade.UpgradeType);

        if (existingUpgrade != null)
        {
            if (existingUpgrade.upgradeLevel < existingUpgrade.upgradeMaxLevel)
            {
                existingUpgrade.upgradeLevel++;
            }
        }
        else
        {
            playerUpgrades.Add(upgrade);
        }
    }

    public UpgradeConfig GetUpgrade(UpgradeType type)
    {
        return playerUpgrades.Find(u => u.UpgradeType == type);
    }
}
