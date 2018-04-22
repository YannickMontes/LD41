using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    private GameObject shotgunHitParticles;
    [SerializeField]
    private GameObject shotgunFireShotParticles;
    [SerializeField]
    private GameObject shotgunFireShotParticles_Anchor;

    public bool IsReloading {
        get; set;
    }

    public Shotgun(string name) : base(name)
    {
    }

    protected internal override void Start()
    {
        base.Start();
        IsReloading = false;
        onFireAction += (Vector3 firstHitPoint) => {
            GameObject goParticles = Instantiate(shotgunHitParticles, firstHitPoint, Quaternion.identity);
            Destroy(goParticles, 3f);
        };
    }

    protected override void OnEnemyHit(Enemy enemy, Vector3 groundHit)
    {
        PaintPlane(enemy, groundHit);
    }

    public override void CastWeaponSkill()
    {
        if (IsReloading == false) {
            base.CastWeaponSkill();
            Animator.SetTrigger("TriggerShoot");
            GameObject fireParticles = Instantiate(shotgunFireShotParticles, shotgunFireShotParticles_Anchor.transform, false);
        }
    }
}
