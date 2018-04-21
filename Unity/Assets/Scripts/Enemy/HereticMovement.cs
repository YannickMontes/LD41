using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HereticMovement : Movement {



    public GameObject target = null;

    public override void Move()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * 5;

  

        Vector3 direction = target.transform.position - transform.position;
        Quaternion targetQuat = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuat, Time.deltaTime);


    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
