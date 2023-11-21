using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeTesting : MonoBehaviour
{
    public Button plusButton;
    public Button minusButton;
    public Image[] targetImages;
    public Color originalColor;
    public Color upgradedColor;
    public int maxUpgrades = 4;

    int upgradeLevel;

    public PermUpgrade permUpgrade;
    public TextMeshProUGUI permCurrencyText;

    private void Start()
    {
        plusButton.onClick.AddListener(PlusButtonClick);
        minusButton.onClick.AddListener(MinusButtonClick);
    }

    private void OnEnable()
    {
        UpdateCurrencyText();

        upgradeLevel = !PlayerManager.Instance.PermUpgrades.ContainsKey(permUpgrade.UpgradeID) ? 0 : PlayerManager.Instance.PermUpgrades[permUpgrade.UpgradeID];

        for (int i = 0; i < targetImages.Length; i++)
        {
            RemoveUpgrade(i);
        }

        for(int i = 0; i < upgradeLevel; i++)
        {
            UpgradeButtonClick(i);
        }
    }

    void UpdateCurrencyText()
    {
        permCurrencyText.text = PlayerManager.Instance.PermCurrency.ToString();
    }

    void PlusButtonClick()
    {
        if (PlayerManager.Instance.BuyUpgrade(permUpgrade))
        {
            upgradeLevel = !PlayerManager.Instance.PermUpgrades.ContainsKey(permUpgrade.UpgradeID) ? 0 : PlayerManager.Instance.PermUpgrades[permUpgrade.UpgradeID];
            UpgradeButtonClick(upgradeLevel - 1);
            UpdateCurrencyText();
        }
    }

    void MinusButtonClick()
    {
        upgradeLevel = !PlayerManager.Instance.PermUpgrades.ContainsKey(permUpgrade.UpgradeID) ? 0 : PlayerManager.Instance.PermUpgrades[permUpgrade.UpgradeID];

        if (PlayerManager.Instance.RefundUpgrade(permUpgrade))
        {
            RemoveUpgrade(upgradeLevel - 1);
            UpdateCurrencyText();
        }
    }

    void UpgradeButtonClick(int buttonIndex)
    {
        for (int i = 0; i <= buttonIndex; i++)
        {
            targetImages[i].color = upgradedColor;
        }
    }

    void RemoveUpgrade(int index)
    {
        if (index < targetImages.Length)
        {
            targetImages[index].color = originalColor;
        }
    }
}
