using UnityEngine;

[CreateAssetMenu(fileName = "NewGeneralUpgradeConfig", menuName = "Upgrade System/General Upgrade Config")]
public class GeneralUpgradeConfig : ScriptableObject
{
    public int baseCost;
    
    public int upgradeLevel;
    public float costMultiplier = 1.5f;

    public int GetCurrentCost()
    {
        return Mathf.RoundToInt(baseCost * Mathf.Pow(costMultiplier, upgradeLevel));
    }

    public void IncreaseUpgradeLevel()
    {
        upgradeLevel++;
    }
}
