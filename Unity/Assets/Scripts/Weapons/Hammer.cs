using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Hammer : Weapon
{
    public Hammer(string name) : base(name)
    {
    
    }

    public override void HitEnemy()
    {
        //pLay anim
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemyScript = collision.collider.gameObject.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            Color enemyColor = enemyScript.Color;
            enemyScript.Die();
            GameObject spriteObject = Instantiate(m_spritePrefab);
            spriteObject.GetComponent<SpriteRenderer>().color = enemyColor;
        }
    }
}
