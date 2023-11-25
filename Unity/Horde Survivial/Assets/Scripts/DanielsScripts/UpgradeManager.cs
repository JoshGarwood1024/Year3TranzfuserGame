using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    List<Upgrade> availableUpgrades = new List<Upgrade>();
    List<Upgrade> equippedUpgrades = new List<Upgrade>();

    [SerializeField]
    GameObject[] upgradeSlots;

    [SerializeField]
    GameObject UpgradePanel;

    public TextMeshProUGUI DamageBuffText, SpeedText, WeaponListText;

    public List<ParticleSystem> gemParticles = new List<ParticleSystem>();
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
        availableUpgrades.Add(gameObject.AddComponent<GiggleGunUpgrade>());
        availableUpgrades.Add(gameObject.AddComponent<BouncyBallUpgrade>());
        availableUpgrades.Add(gameObject.AddComponent<SockPuppetUpgrade>());
        availableUpgrades.Add(gameObject.AddComponent<MarshmellowMaceUpgrade>());
        availableUpgrades.Add(gameObject.AddComponent<JigsawSlicerUpgrade>());
        availableUpgrades.Add(gameObject.AddComponent<UnicornHornUpgrade>());

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
        float rarity = Random.Range(0, 101);

        foreach (Upgrade u in availableUpgrades)
        {
            if(u.rarity >= rarity)
            {
                possibleUpgrades.Add(u);
            }
        }

        foreach (Upgrade u in equippedUpgrades)
        {
            if (u.rarity >= rarity)
            {
                possibleUpgrades.Add(u);
            }
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
        //STATS PAGE
        DamageBuffText.text = "Damage Buff: " + PlayerData.Instance.DamageBuff;
        SpeedText.text = "Speed: " + PlayerData.Instance.gameObject.GetComponent<PlayerMovement>().moveSpeed;
        WeaponListText.text = string.Join("\n -", PlayerManager.Instance.weaponList);

        //UPGRADES PAGE
        Time.timeScale = 0.0f;
        UpgradePanel.SetActive(true);

        Upgrade[] selectedUpgrades = GetUpgrades();

        for(int i = 0; i < 3; i++)
        {
            upgradeSlots[i].GetComponent<UpgradesPanel>().ShowUpgrade(selectedUpgrades[i]);
        }

        foreach(ParticleSystem p in gemParticles)
        {
            p.Play();
        }
    }

    public void ClosePanel(Upgrade chosenUpgrade)
    {
        foreach (ParticleSystem p in gemParticles)
        {
            p.Stop();
            p.Clear();
        }

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
