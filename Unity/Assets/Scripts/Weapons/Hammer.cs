using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    public Hammer(string name) : base(name)
    {
    
    }

    public override void HitEnemy()
    {
        if (m_animator)
            m_animator.SetBool("TriggerHammerHit", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            PaintPlane(enemyScript);
        }
    }

    private void PaintPlane(Enemy enemyScript)
    {
        GameObject spriteObject = Instantiate(m_splatPrefab , enemyScript.transform.position, Quaternion.identity);
        SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = enemyScript.GetColor();
        spriteRenderer.sprite = SplatSprite;
        spriteObject.transform.LookAt(enemyScript.transform.position + Vector3.up);

        GameObject particles = Instantiate(m_particlesPrefab, enemyScript.transform.position, Quaternion.identity);
        particles.GetComponent<ParticlesSplasher>().SetColor(enemyScript.GetColor());
        Destroy(particles, 3.0f);

        enemyScript.Die();
    }
}
