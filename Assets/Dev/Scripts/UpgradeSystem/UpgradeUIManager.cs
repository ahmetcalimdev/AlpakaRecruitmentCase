using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeUIManager : MonoBehaviour
{

    [SerializeField] private List<UpgradeButton> buttons = new List<UpgradeButton>();
    [SerializeField] private Button continueButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TextMeshProUGUI playerMoneyTxt;
    private void OnEnable()
    {
        UpdateUIAfterUpgrade();
        GameEvents.OnUpgrade += OnUpgrade;
        continueButton.onClick.AddListener(()=> SceneManager.LoadScene(0));
    }

    private void OnUpgrade(UpgradeConfig config, int arg2)
    {
        UpdateUIAfterUpgrade();
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveAllListeners();
    }
    private void UpdateUIAfterUpgrade() 
    {
        playerMoneyTxt.text = GameManager.Instance.playerConfig.playerMoney.ToString();
        upgradeButton.interactable = GameManager.Instance.playerConfig.playerMoney > UpgradeManager.Instance.generalUpgradeConfig.GetCurrentCost();
    }
    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    public void UpgradeRandom() 
    {
        StartCoroutine(HighlightRandomUpgrades());
    }
    private IEnumerator HighlightRandomUpgrades()
    {
        List<UpgradeButton> shuffledUpgrades = new List<UpgradeButton>(buttons);
        shuffledUpgrades = shuffledUpgrades.Where(t => t.config.isActive).ToList();
        ShuffleList(shuffledUpgrades);

        for (int i = 0; i < 3; i++)
        {
            foreach (UpgradeButton upgradeButton in shuffledUpgrades)
            {
                upgradeButton.Highlight(true);
                yield return new WaitForSeconds(.1f);
                upgradeButton.Highlight(false);
            }
        }
        UpgradeButton selectedUpgrade = shuffledUpgrades[shuffledUpgrades.Count - 1];
        UpgradeManager.Instance.Upgrade(selectedUpgrade);
        selectedUpgrade.Highlight(true);
    }
}
