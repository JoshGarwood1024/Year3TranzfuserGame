using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MarshmellowMace : Weapon
{
    List<GameObject> maces = new List<GameObject>();
    GameObject maceParent;

    [SerializeField]
    int numberOfMaces;
    float permRotationIncrease = 1;

    protected override void Start()
    {
        base.Start();

        maceParent = new GameObject("MaceParent");
        maceParent.transform.position = transform.position;
        maceParent.transform.parent = transform;

        if (active) Activate();
    }

    public override void Activate()
    {
        base.Activate();

        numberOfMaces = 1;

        SpawnMaces();
    }

    protected override void Update()
    {
        base.Update();

        maceParent.transform.Rotate(Vector3.forward * 60f * permRotationIncrease * Time.deltaTime);
    }

    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        DamageIncrease += 10;
        AddMace();

        if (MaxLevel) MaxLevelFunc();
    }

    void MaxLevelFunc()
    {
        foreach (Transform obj in maceParent.transform)
        {
            Destroy(obj.gameObject);
        }

        float angle = 360f;
        Vector3 spawnPosition = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * 2, Mathf.Sin(angle * Mathf.Deg2Rad) * 2, 0f);
        spawnPosition *= 1.7f;

        GameObject mace = Instantiate(WeaponPrefab, transform.position + spawnPosition, Quaternion.identity);
        mace.GetOrAddComponent<HurtEnemyOnTrigger>().Damage = 150 + PermDamageIncrease;
        mace.transform.parent = maceParent.transform;
        mace.transform.rotation = Quaternion.Euler(0f, 0f, angle - 45f);
        mace.transform.localScale *= 1.7f;
    }
    void AddMace()
    {
        numberOfMaces++;

        foreach(Transform obj in maceParent.transform)
        {
            Destroy(obj.gameObject);
        }

        SpawnMaces();
    }

    public override void ApplyPermUpgrade(int level)
    {
        base.ApplyPermUpgrade(level);

        for (int i = 0; i < level; i++)
        {
            permRotationIncrease += 0.1f;
        }
    }
    void SpawnMaces()
    {
        for (int i = 0; i < numberOfMaces; i++)
        {
            float angle = i * 360f / numberOfMaces;
            Vector3 spawnPosition = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * 2, Mathf.Sin(angle * Mathf.Deg2Rad) * 2, 0f);

            GameObject mace = Instantiate(WeaponPrefab, transform.position + spawnPosition, Quaternion.identity);
            mace.GetOrAddComponent<HurtEnemyOnTrigger>().Damage = WeaponData.Damage + DamageIncrease + PermDamageIncrease;
            mace.transform.rotation = Quaternion.Euler(0f, 0f, angle - 45f);
            mace.transform.parent = maceParent.transform;
        }
    }

}
