using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{

    public string upgradeName { get; set; }
    public float rarity { get; set; }
    public string description { get; set; }


    public virtual void Equip() { }
    public virtual void Use() { }

    public virtual void GetLevelUpgrade() { }
    public virtual void LevelUp() { }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class BreathOfTheWild : Upgrade
{
    private void Start()
    {
        rarity = 80;
        upgradeName = "Breath of the Wild";
    }

    public override void Use()
    {
        Debug.Log("Breath of the wild");
    }
}

public class MindsFocus : Upgrade
{
    private void Start()
    {
        rarity = 20;
        upgradeName = "Minds Focus";

    }
    public override void Use()
    {
        Debug.Log("Minds Focus");
    }
}

public class Test1 : Upgrade
{
    private void Start()
    {
        rarity = 100;
        upgradeName = "Test 1";
    }

    public override void Use()
    {
        Debug.Log("Test 1");
    }
}

public class Test2 : Upgrade
{
    private void Start()
    {
        upgradeName = "Test 2";
        rarity = 100;

    }
    public override void Use()
    {
        Debug.Log("Test 2");
    }
}

public class Test3 : Upgrade
{
    private void Start()
    {
        upgradeName = "Test 3";
        rarity = 100;

    }
    public override void Use()
    {
        Debug.Log("Test 3");
    }
}
