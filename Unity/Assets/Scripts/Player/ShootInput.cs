using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {

    [SerializeField]
    private float range = 1.0f;
    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private GameObject spritePrefab;

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
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitPoint, range))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward, Color.blue, 2.0f);

            Enemy target = hitPoint.transform.GetComponent<Buggy>();

            if (target != null)
            {
                GameObject spriteObject = Instantiate(spritePrefab, target.transform.position, Quaternion.identity);
                SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
                spriteRenderer.color = target.Material.color;
                spriteRenderer.sprite = sprite;
                spriteObject.transform.LookAt(target.transform.position + Vector3.up);

                target.Die();
            }
        }
    }

    private bool InputShoot()
    {
        return Input.GetMouseButtonDown(0);
    }
}
