using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapnel_GrabTrigger : MonoBehaviour {

    [SerializeField]
    Grapnel grapnel;

    [SerializeField]
    Animator grapnelAnimator;

    Collider grabZoneCollider;

	void Start () {
        grabZoneCollider = this.GetComponent<Collider>();
        grabZoneCollider.enabled = false;
    }
	

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
        if (enemyScript != null) {
            grabZoneCollider.enabled = false;
            enemyScript.canMove = false;
            enemyScript.gameObject.transform.SetParent(transform, true);
            Rigidbody enemyRB = enemyScript.GetComponent<Rigidbody>();
            enemyRB.velocity = Vector3.zero;
            grapnel.grabbedBug = enemyScript;
            grapnel.HasGrabbedSomething = true;
            grapnelAnimator.SetBool("SomethingGrabbed", true);
        }
    }
}
