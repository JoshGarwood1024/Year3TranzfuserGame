using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PermUpgrade", menuName = "ScriptableObjects/PermUpgrade")]
public class PermUpgrade : ScriptableObject
{
    public string UpgradeID;
    public int Cost;

    [TextArea(3, 5)]
    public string Description;
}
