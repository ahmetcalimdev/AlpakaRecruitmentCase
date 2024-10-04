using UnityEngine;
[CreateAssetMenu(fileName = "NewUpgradeConfig", menuName = "Upgrade System/Upgrade Config")]
public class UpgradeConfig : ScriptableObject
{
    public string upgradeName;
    public int upgradeLevel;
    public int upgradeMaxLevel;

    public bool isActive;
    public UpgradeType UpgradeType;
    public Sprite Icon;
}
