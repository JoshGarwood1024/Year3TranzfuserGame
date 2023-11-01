using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    List<Upgrade> availableUpgrades = new List<Upgrade>();
    List<Upgrade> equippedUpgrades = new List<Upgrade>();

    [SerializeField]
    GameObject[] upgradeSlots;

    [SerializeField]
    GameObject UpgradePanel;

    public static UpgradeManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //----MID GAME UPGRADES----
        availableUpgrades.Add(gameObject.AddComponent<DamageUpgrade>());
        availableUpgrades.Add(gameObject.AddComponent<HealthUpgrade>());

        //----WEAPONS----
        availableUpgrades.Add(gameObject.AddComponent<BalloonBombUpgrade>());
        availableUpgrades.Add(gameObject.AddComponent<PillowBatUpgrade>());
        availableUpgrades.Add(gameObject.AddComponent<BubbleGumBazookaUpgrade>());
        availableUpgrades.Add(gameObject.AddComponent<FairyDustBlowerUpgrade>());

        switch (PlayerManager.Instance.PlayersClass)
        {
            case StartingClass.Breathing:

                EquipStartingClass(gameObject.AddComponent<BreathingUpgrade>());
                break;
        }
    }

    Upgrade[] GetUpgrades()
    {
        List<Upgrade> possibleUpgrades = new List<Upgrade>();

        foreach (Upgrade u in availableUpgrades)
        {
            possibleUpgrades.Add(u);
        }

        foreach (Upgrade u in equippedUpgrades)
        {
            possibleUpgrades.Add(u);
        }

        Upgrade[] selectedUpgrades = new Upgrade[3];

        for(int i = 0; i < 3; i++)
        {
            if(possibleUpgrades.Count > 0)
            {
                selectedUpgrades[i] = possibleUpgrades[Random.Range(0, possibleUpgrades.Count - 1)];
                possibleUpgrades.Remove(selectedUpgrades[i]);
            } else
            {
                selectedUpgrades[i] = selectedUpgrades[i - 1];
            }

        }

        return selectedUpgrades;
    }

    public void OpenPanel()
    {
        Time.timeScale = 0.0f;
        UpgradePanel.SetActive(true);

        Upgrade[] selectedUpgrades = GetUpgrades();

        for(int i = 0; i < 3; i++)
        {
            upgradeSlots[i].GetComponent<UpgradesPanel>().ShowUpgrade(selectedUpgrades[i]);
        }
    }

    public void ClosePanel(Upgrade chosenUpgrade)
    {
        UpgradePanel.SetActive(false);

        ChosenUpgrade(chosenUpgrade);
    }

    void EquipStartingClass(Upgrade upgrade)
    {
        upgrade.Equip();
        equippedUpgrades.Add(upgrade);
    }

    public void ChosenUpgrade(Upgrade upgrade)
    {
        if (equippedUpgrades.Contains(upgrade))
        {
            upgrade.LevelUp();
            if (upgrade.level >= 5)
            {
                equippedUpgrades.Remove(upgrade); //max level
            }
        } else
        {
            upgrade.Equip();
            equippedUpgrades.Add(upgrade);
            availableUpgrades.Remove(upgrade);
        }
    }
}
