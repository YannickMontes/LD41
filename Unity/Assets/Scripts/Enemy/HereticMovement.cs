using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HereticMovement : Movement {


    public float limit = 5.0f;
    public float coeff = 15f;
    public float currentSpeed;

    public override void Move()
    {
        
        Rigidbody rb = this.GetComponent<Rigidbody>();
        if(rb.velocity.magnitude <= limit)
            rb.AddForce(transform.forward * coeff);

        currentSpeed = rb.velocity.magnitude;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
