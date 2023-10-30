using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    public string WeaponName;
    public string Description;
    public string UpgradeDescription;
    public int Level;
    public float Damage;
    public float Cooldown;


}
