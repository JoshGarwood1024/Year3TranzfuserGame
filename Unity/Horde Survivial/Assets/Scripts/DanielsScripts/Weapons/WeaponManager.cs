using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Dictionary<string, int> pu = PlayerManager.Instance.PermUpgrades;

        foreach(KeyValuePair<string,int> entry in pu)
        {
            string upgradeID = entry.Key;
            int level = entry.Value;

            if(GetComponent(upgradeID) != null)
            {
                Weapon w = GetComponent(upgradeID) as Weapon;
                w.ApplyPermUpgrade(level);
            }
            else
            {
                switch (upgradeID)
                {
                    case "Health":
                        for(int i = 0; i < level; i++)
                        {
                            PlayerData.Instance.HealthBuff += 25;
                        }
                        break;
                    //speed
                }


            }
        }
    }
}