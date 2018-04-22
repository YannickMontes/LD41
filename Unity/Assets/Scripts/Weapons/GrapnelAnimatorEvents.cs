using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapnelAnimatorEvents : MonoBehaviour {

    [SerializeField]
    Grapnel grapnel;

    [SerializeField]
    private Collider grapnelGrabZone;

    void Start()
    {
        grapnelGrabZone.enabled = false;
    }

    public void SetColliderActive()
    {
        grapnelGrabZone.enabled = true;
    }


    public void SetColliderInactive()
    {
        grapnelGrabZone.enabled = false;
    }

    public void ThrowEnemy()
    {
        grapnel.ThrowEnemyEffectively_IMeanItWillBeShot();
    }

}
