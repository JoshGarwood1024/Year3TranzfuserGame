using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    List<Upgrade> upgrades = new List<Upgrade>();
    List<Upgrade> currentUpgrades = new List<Upgrade>();

    GameObject player;
    public GameObject upgradesPanel;
    public List<GameObject> upgradeSlots;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        upgrades.Add(player.AddComponent<HealthUpgrade>());
        upgrades.Add(player.AddComponent<DamageUpgrade>());
        upgrades.Add(player.AddComponent<RangeAttack>());
        upgrades.Add(player.AddComponent<SlashAttack>());

        //starting item
        ApplyUpgrade(player.GetComponent<SlashAttack>());
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Upgrade u in currentUpgrades)
        {
            u.Use();
        }
    }

    public void ShowPanel()
    {
        Time.timeScale = 0.0f;
        upgradesPanel.SetActive(true);

        //Upgrade upgradeForSlot = ChooseUpgrade();

        //Make it so it doesnt choose the same 
        int rarity = Random.Range(0, 100);
        List<Upgrade> slotUpgrades = ChooseUpgrade(rarity);

        if(slotUpgrades[0])
        {
            upgradeSlots[0].GetComponent<UpgradesPanel>().ShowUpgrade(slotUpgrades[0]);
        }
        
        if(slotUpgrades[1])
        {
            upgradeSlots[1].GetComponent<UpgradesPanel>().ShowUpgrade(slotUpgrades[1]);
        }

        if(slotUpgrades[2])
        {
            upgradeSlots[2].GetComponent<UpgradesPanel>().ShowUpgrade(slotUpgrades[2]);
        }
    }

    public void ApplyUpgrade(Upgrade upgrade)
    {
        if (!currentUpgrades.Contains(upgrade))
        {
            currentUpgrades.Add(upgrade);
            upgrades.Remove(upgrade);
            upgrade.Equip();
            
        } else
        {
            Debug.Log("TEST2" + upgrade.upgradeName);
            currentUpgrades.Find(upgrade => upgrade).LevelUp();
            if (upgrade.level >= 5)
            {
                currentUpgrades.Remove(upgrade); //max level
            }
            
        }
    }

    List<Upgrade> ChooseUpgrade(int rarity)
    {
        List<Upgrade> possibleUpgrades = new List<Upgrade>();
        List<Upgrade> sentUpgrades = new List<Upgrade>();

        foreach (Upgrade u in upgrades)
        {
            if (rarity <= u.rarity)
            {
                possibleUpgrades.Add(u);
            }
        }

        foreach (Upgrade u in currentUpgrades)
        {
            if (rarity <= u.rarity)
            {
                possibleUpgrades.Add(u);
            }
        }

        if (possibleUpgrades.Count > 0)
        {
            for(int i = 0; i < 3; i++)
            {
                int random = Random.Range(0, possibleUpgrades.Count);
                sentUpgrades.Add(possibleUpgrades[random]);
                possibleUpgrades.Remove(possibleUpgrades[random]);
            }
        }

        return sentUpgrades;
    }

    public void ClosePanel()
    {
        upgradesPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
