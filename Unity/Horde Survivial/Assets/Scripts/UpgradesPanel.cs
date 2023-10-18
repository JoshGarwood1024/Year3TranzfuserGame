using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradesPanel : MonoBehaviour
{

    public Upgrade shownUpgrade;
    public TextMeshProUGUI title;
    public TextMeshProUGUI desc;

    GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
    }

    public void ShowUpgrade(Upgrade upgrade)
    {
        shownUpgrade = upgrade;
        title.text = upgrade.upgradeName;
        desc.text = upgrade.level > 0 ? upgrade.equippedDescription : upgrade.baseDescription;
    }

    public void Pressed()
    {
        GM.GetComponent<UpgradeSystem>().ApplyUpgrade(shownUpgrade);
        GM.GetComponent<UpgradeSystem>().ClosePanel();
    }

    //Update is called once per frame
    void Update()
    {

    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1.0f;
    }
}
