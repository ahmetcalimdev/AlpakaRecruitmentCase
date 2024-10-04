
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private Image _highlight;
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private TextMeshProUGUI _nameTxt;
    [SerializeField]
    private TextMeshProUGUI _levelTxt;
    [SerializeField]
    private Color _highlightColor;
    [SerializeField]
    private Color _unHighlightColor;
    public UpgradeConfig config;

    private void OnEnable()
    {
        GameEvents.OnUpgrade += OnUpgrade;
    }
    private void OnDisable()
    {
        GameEvents.OnUpgrade -= OnUpgrade;

    }
    private void OnUpgrade(UpgradeConfig upgradedConfig, int cost)
    {
        if (upgradedConfig == config)
        {
            config.upgradeLevel++;
            UpdateStats();
        }
    }

  
    private void OnValidate()
    {
        UpdateStats();
    }
    public void UpdateStats()
    {

        config.isActive = config.upgradeLevel < config.upgradeMaxLevel;
        _icon.sprite = config.Icon;
        _nameTxt.text = config.upgradeName;
        _levelTxt.text = "Lv." + config.upgradeLevel;
    }
    public void Highlight(bool enabled) 
    {
        if (enabled)
            _highlight.color = _highlightColor;
        else
            _highlight.color = _unHighlightColor;
       
    }
}
