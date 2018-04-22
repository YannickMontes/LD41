using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HereticMovement : Movement {

    [SerializeField]
    private GameObject map;


    float width=0;
    float height=0;


    public override void Move(GameObject targetGO, bool canMoveInCanvas)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * 5;  

        Vector3 direction = targetGO.transform.position - transform.position;
        Quaternion targetQuat = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuat, Time.deltaTime);


        if (Vector3.Distance(transform.position, targetGO.transform.position) <= 2.0f && canMoveInCanvas)
        {
            float randomWidth = UnityEngine.Random.Range(-width/2, width/2);
            float randomHeight = UnityEngine.Random.Range(-height/2, height/2);
            targetGO.transform.position = new Vector3(randomWidth, 0, randomHeight);
        }

    }



    // Use this for initialization
    void Start () {

        width = map.transform.localScale.x;
        height = map.transform.localScale.z;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
