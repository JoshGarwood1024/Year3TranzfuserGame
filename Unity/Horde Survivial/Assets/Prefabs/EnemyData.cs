using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemys", menuName="Enemys / New Enemy Data", order = 1)]

public class EnemyData : ScriptableObject
{
    public string displayName;
    public string description;

    public int health;
    public float speed;



}
