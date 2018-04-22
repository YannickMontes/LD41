using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAnimatorEvents : MonoBehaviour {

    [SerializeField]
    private Collider hammerCollider;

    void Start()
    {
        hammerCollider.enabled = false;
    }

    public void SetColliderActive()
    {
        hammerCollider.enabled = true;
    }


    public void SetColliderInactive()
    {
        hammerCollider.enabled = false;
    }

}
