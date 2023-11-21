using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTesting : MonoBehaviour
{
    public Button plusButton;
    public Button minusButton;
    public Image[] targetImages;
    public Color originalColor;
    public Color upgradedColor;
    public int maxUpgrades = 4;

    private int currentUpgrades = 0;

    private void Start()
    {
        plusButton.onClick.AddListener(PlusButtonClick);
        minusButton.onClick.AddListener(MinusButtonClick);
    }

    void PlusButtonClick()
    {
        if (currentUpgrades < maxUpgrades)
        {
            UpgradeButtonClick(currentUpgrades);
            currentUpgrades++;
        }
    }

    void MinusButtonClick()
    {
        if (currentUpgrades > 0)
        {
            currentUpgrades--;
            RemoveUpgrade(currentUpgrades);
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
