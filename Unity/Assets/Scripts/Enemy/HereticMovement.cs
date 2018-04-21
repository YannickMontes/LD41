using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HereticMovement : Movement {

    float width = 70;
    float height = 100;

    public GameObject target = null;
    public GameObject ground = null;

    public override void Move()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * 5;  

        Vector3 direction = target.transform.position - transform.position;
        Quaternion targetQuat = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuat, Time.deltaTime);


        if (Vector3.Distance(transform.position, target.transform.position) <= 2.0f)
        {
            width = ground.GetComponent<RectTransform>().rect.width;
            height = ground.GetComponent<RectTransform>().rect.height;
            float randomWidth = UnityEngine.Random.Range(-width/2, width/2);
            float randomHeight = UnityEngine.Random.Range(-height/2, height/2);
            target.transform.position = new Vector3(randomWidth, 0, randomHeight);
        }

    }


    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
