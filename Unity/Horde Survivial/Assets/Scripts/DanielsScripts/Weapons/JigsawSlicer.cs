using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawSlicer : Weapon
{
    public List<Sprite> puzzlePieceSprites = new List<Sprite>();
    protected override void Attack()
    {
        base.Attack();

        for (int i = 0; i < 360; i += 45)
        {
            GameObject puzzle = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);

            Vector3 dir = Quaternion.Euler(0f, 0f, i) * new Vector3(1f, 0f, 0f).normalized;
            puzzle.GetComponent<Rigidbody2D>().velocity = dir * 15;
            puzzle.GetComponent<HurtEnemyOnTrigger>().Damage = MaxLevel? 150 + PermDamageIncrease : WeaponData.Damage + DamageIncrease + PermDamageIncrease;
            puzzle.GetComponent<SpriteRenderer>().sprite = puzzlePieceSprites[Random.Range(0, puzzlePieceSprites.Count)];

            if(Random.Range(0, 101) > 10 * currentLevel)
            {
                GameObject Extrapuzzle = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);

                dir = Quaternion.Euler(0f, 0f, i) * new Vector3(1f, 0f, 0f).normalized;
                Extrapuzzle.GetComponent<Rigidbody2D>().velocity = dir * 15;
                Extrapuzzle.GetComponent<HurtEnemyOnTrigger>().Damage = MaxLevel ? 150 : WeaponData.Damage + DamageIncrease + PermDamageIncrease;
                Extrapuzzle.GetComponent<SpriteRenderer>().sprite = puzzlePieceSprites[Random.Range(0, puzzlePieceSprites.Count)];
            
                if(MaxLevel) Extrapuzzle.transform.localScale *= 1.3f;
            }

            if (MaxLevel) puzzle.transform.localScale *= 1.3f;
        }
    }

    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        DamageIncrease += 10;
        if (WeaponData.Cooldown - CooldownReduction > 0.5f) CooldownReduction += 0.3f;
    }

    public override void ApplyPermUpgrade(int level)
    {
        base.ApplyPermUpgrade(level);
        
        for (int i = 0; i < level; i++)
        {
            PermDamageIncrease += 20;
        }
    }
}