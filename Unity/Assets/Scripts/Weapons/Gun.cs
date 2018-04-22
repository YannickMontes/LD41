using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : Weapon {

    [SerializeField]
    protected float m_range;

    protected Camera m_camera;

    public Action<Vector3> onFireAction;

    protected internal virtual void Start()
    {
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public Gun(string name) : base(name)
    {
    }

    public override void CastWeaponSkill()
    {
        //TODO: FX

        RaycastHit[] hitPoints = null;
        hitPoints = Physics.RaycastAll(m_camera.transform.position, m_camera.transform.forward, m_range);
        if (hitPoints.Length > 0)
        {
            List<Enemy> enemies = new List<Enemy>();
            RaycastHit ground = new RaycastHit();
            foreach (RaycastHit hit in hitPoints)
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemies.Add(enemy);
                }
                else if (hit.transform.tag == "PaintingZone")
                {
                    ground = hit;
                }
            }
            foreach (Enemy enemy in enemies)
            {
                OnEnemyHit(enemy, ground.point);

            }
            if (onFireAction != null) {
                onFireAction(hitPoints[0].point);
            }
        }
    }

    protected abstract void OnEnemyHit(Enemy enemy, Vector3 groundHit);
}
