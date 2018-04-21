using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {

    [SerializeField]
    private float range = 1.0f;

    private Transform cameraTransform;

	// Use this for initialization
	void Start ()
    {
        cameraTransform = gameObject.GetComponentInChildren<Camera>().transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (InputShoot())
        {
            ShootRaycast();
        }
	}

    private void ShootRaycast()
    {
        RaycastHit hitPoint;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitPoint, range, ~(1 << 8)))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward, Color.blue, 2.0f);

            Enemy target = hitPoint.transform.GetComponent<Enemy>();

            if (target != null)
            {
                //
            }
        }
    }

    private bool InputShoot()
    {
        return Input.GetMouseButtonDown(0);
    }
}
