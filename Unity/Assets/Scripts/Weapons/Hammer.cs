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
            PaintPlane(enemyScript);
        }
    }

    private void PaintPlane(Enemy enemyScript)
    {
        GameObject spriteObject = Instantiate(m_splatPrefab , enemyScript.transform.position, Quaternion.identity);
        SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = enemyScript.Material.color;
        spriteRenderer.sprite = SplatSprite;
        spriteObject.transform.LookAt(enemyScript.transform.position + Vector3.up);

        enemyScript.Die();
    }
}
