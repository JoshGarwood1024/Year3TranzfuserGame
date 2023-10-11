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

        upgrades.Add(player.AddComponent<BreathOfTheWild>());
        upgrades.Add(player.AddComponent<MindsFocus>());
        upgrades.Add(player.AddComponent<Test1>());
        upgrades.Add(player.AddComponent<Test2>());
        upgrades.Add(player.AddComponent<Test3>());
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
        upgradeSlots[0].GetComponent<UpgradesPanel>().ShowUpgrade(ChooseUpgrade(rarity));


        upgradeSlots[1].GetComponent<UpgradesPanel>().ShowUpgrade(ChooseUpgrade(rarity));


        upgradeSlots[2].GetComponent<UpgradesPanel>().ShowUpgrade(ChooseUpgrade(rarity));

    }

    public void ApplyUpgrade(Upgrade upgrade)
    {
        if(!currentUpgrades.Contains(upgrade))
        {
            currentUpgrades.Add(upgrade);
        } else
        {
            currentUpgrades.Find(upgrade => upgrade).LevelUp();
        }
    }

    Upgrade ChooseUpgrade(int rarity)
    {
        List<Upgrade> possibleUpgrades = new List<Upgrade>();

        foreach (Upgrade u in upgrades)
        {
            if (rarity <= u.rarity)
            {
                possibleUpgrades.Add(u);
            }
        }

        if(possibleUpgrades.Count > 0)
        {
            Upgrade upg = possibleUpgrades[Random.Range(0, possibleUpgrades.Count)];
            return upg;
        }

        return null;
    }

    public void ClosePanel()
    {
        upgradesPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
