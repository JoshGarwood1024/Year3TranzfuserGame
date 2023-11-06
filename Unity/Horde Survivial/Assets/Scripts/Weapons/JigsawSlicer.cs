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
            puzzle.GetComponent<HurtEnemyOnTrigger>().Damage = WeaponData.Damage;
            puzzle.GetComponent<SpriteRenderer>().sprite = puzzlePieceSprites[Random.Range(0, puzzlePieceSprites.Count)];
        }
    }
}