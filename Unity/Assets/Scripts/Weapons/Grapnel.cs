using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapnel : Weapon {

    [SerializeField]
    private GameObject grabZone;
    
    [HideInInspector]
    public Enemy grabbedBug;

    public bool HasGrabbedSomething {
        get; set;
    }

    public Grapnel(string name) : base(name)
    {
    }

    public override void CastWeaponSkill(float chargeScale)
    {
        if (m_animator) {
            if (HasGrabbedSomething) {
                m_animator.SetBool("TriggerThrow", true);
            } else {
                m_animator.SetBool("SomethingGrabbed", false);
                m_animator.SetBool("TriggerGrab", true);
            }
        }
    }

    public void ThrowEnemyEffectively_IMeanItWillBeShot()
    {
        if (grabbedBug == null) {
            return;
        }
        Vector3 direction = Camera.main.transform.forward;
        Rigidbody bugRb = grabbedBug.GetComponent<Rigidbody>();
        grabbedBug.transform.parent = null;
        if (grabbedBug.transform.position.y <= 0.0f)
            grabbedBug.transform.position = new Vector3(grabbedBug.transform.position.x, 0.5f, grabbedBug.transform.position.z);
        bugRb.useGravity = true;
        bugRb.AddForce(direction * 2000f);
        HasGrabbedSomething = false;
        grabbedBug.IsBomb = true;
    }

}
