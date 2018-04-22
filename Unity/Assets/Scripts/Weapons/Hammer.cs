using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    public Hammer(string name) : base(name)
    {
    
    }

    public override void CastWeaponSkill()
    {
        if (m_animator)
            m_animator.SetBool("TriggerHammerHit", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            PaintPlane(enemyScript, Vector3.zero, Vector3.zero);
        }
    }

}
