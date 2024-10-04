using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUpgradeButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI priceTxt;
    [SerializeField]
    private Button btn;
    [SerializeField]
    private UpgradeUIManager upgradeUIManager;

    private void OnEnable()
    {
        GameEvents.OnUpgrade += OnUpgrade;
        btn.onClick.AddListener(upgradeUIManager.UpgradeRandom);

    }
    private void OnDisable()
    {
        GameEvents.OnUpgrade -= OnUpgrade;
        btn.onClick.RemoveListener(upgradeUIManager.UpgradeRandom);  
    }

    private void OnUpgrade(UpgradeConfig config)
    {
        UpgradeManager.Instance.generalUpgradeConfig.upgradeLevel++;
        UpdatePriceTxt();
    }

    private void UpdatePriceTxt()
    {
        priceTxt.text ="$" + UpgradeManager.Instance.generalUpgradeConfig.GetCurrentCost().ToString();
    }
}
