using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradesPanel : MonoBehaviour
{

    public Upgrade shownUpgrade;
    public TextMeshProUGUI title;
    public TextMeshProUGUI desc;

    public void ShowUpgrade(Upgrade upgrade)
    {
        shownUpgrade = upgrade;
        title.text = upgrade.upgradeName;
        desc.text = upgrade.level > 0 ? upgrade.equippedDescription : upgrade.baseDescription;
    }

    public void Pressed()
    {
        UpgradeManager.Instance.ClosePanel(shownUpgrade);
        Time.timeScale = 1.0f;
    }
}
