using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public List<Sprite> PetSprites;

    public static PlayerManager Instance;

    GameObject pet;

    public int PermCurrency = 0;
    public Dictionary<string, int> PermUpgrades = new Dictionary<string, int>();

    public List<string> weaponList = new List<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        Save();
    }
    public StartingClass PlayersClass { get; private set; }
    public Pet PlayersPet { get; private set; }
    private void Start()
    {
        PlayersClass = StartingClass.Breathing;

        pet = GameObject.Find("PlayersPet");

        PlayersPet = Pet.Dog;

        PermCurrency = PlayerPrefs.GetInt("PermCurrency", 0);
    }

    public bool BuyUpgrade(PermUpgrade permUpgrade)
    {
        string upgradeID = permUpgrade.UpgradeID;
        int cost = PermUpgrades.ContainsKey(upgradeID) ? permUpgrade.Cost + PermUpgrades[upgradeID] * 2 : permUpgrade.Cost;

        if (PermCurrency >= cost)
        {
            if(PermUpgrades.ContainsKey(upgradeID))
            {
                if (PermUpgrades[upgradeID] == 4) return false;

                PermUpgrades[upgradeID]++;
            } else
            {
                PermUpgrades.Add(upgradeID, 1);
            }
          
            PermCurrency -= cost;
            return true;
        }

        return false;
    }

    public bool RefundUpgrade(PermUpgrade permUpgrade)
    {
        string upgradeID = permUpgrade.UpgradeID;
        int refund = PermUpgrades.ContainsKey(upgradeID) ? permUpgrade.Cost + (PermUpgrades[upgradeID] - 1) * 2 : permUpgrade.Cost;

        if (PermUpgrades.ContainsKey(upgradeID))
        {
            PermCurrency += refund;
            PermUpgrades[upgradeID]--;

            if (PermUpgrades[upgradeID] <= 0) PermUpgrades.Remove(upgradeID);

            return true;
        }

        return false;
    }

    public void SetStartingClass(StartingClass sc)
    {
        PlayersClass = sc;
    }

    public Sprite GetPetSprite()
    {
        return PetSprites[(int)PlayersPet];
    }

    public void Save()
    {
        PlayerPrefs.SetInt("PermCurrency", PermCurrency);
    }

}

public enum StartingClass
{ 
    Meditation,
    Breathing,
    Exercise,
    Social
}

public enum Pet
{ 
    Dog = 0,
    Cat = 1,
    Bird = 2
}
