using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeUIManager : MonoBehaviour
{

    [SerializeField] private List<UpgradeButton> buttons = new List<UpgradeButton>();
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
