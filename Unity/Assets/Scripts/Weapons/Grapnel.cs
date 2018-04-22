using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapnel : Weapon {

    public bool HasGrabbedSomething {
        get; set;
    }

    public Grapnel(string name) : base(name)
    {
    }

    public override void CastWeaponSkill()
    {
        if (m_animator)
            m_animator.SetBool("TriggerGrab", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
        if (enemyScript != null) {
            PaintPlane(enemyScript, Vector3.zero, Vector3.zero);
        }
    }


}
