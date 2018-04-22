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

    public override void CastWeaponSkill(float chargeScale)
    {
        if (m_animator)
            m_animator.SetBool("TriggerGrab", true);
    }

    private void OnTriggerEnter(Collider other)
    public void ThrowEnemyEffectively_IMeanItWillBeShot()
    {
<<<<<<< HEAD
        Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
        if (enemyScript != null) {
            PaintPlane(enemyScript, Vector3.zero, Vector3.zero, 1.0f);
=======
>>>>>>> db6fd13d9d1ea53bbdf1cfb48715ab5184d89e51
        }
    }


}
