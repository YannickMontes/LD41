using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : Weapon {

    [SerializeField]
    protected float m_range;

    protected Camera m_camera;

    private void Start()
    {
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public Gun(string name) : base(name)
    {
    }

    public override void CastWeaponSkill()
    {
        //TODO: FX

        RaycastHit hitPoint;
        Debug.Log("Gun shot");
        if (Physics.Raycast(transform.position, m_camera.transform.forward, out hitPoint, m_range))
        {
            Debug.Log("Ray hit "+ hitPoint.transform.name);
            Debug.DrawRay(transform.position, m_camera.transform.forward, Color.blue);
            Enemy enemy = hitPoint.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                OnEnemyHit(enemy);
            }
        }
    }

    protected abstract void OnEnemyHit(Enemy enemy);
}
