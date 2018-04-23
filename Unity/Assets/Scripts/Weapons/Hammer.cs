using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{

    [SerializeField]
    private AudioSource sprootchAS;

    private float m_chargeScale;

    public Hammer(string name) : base(name)
    {
    
    }

    public override void CastWeaponSkill(float chargeScale)
    {
        if (m_animator)
            m_animator.SetBool("TriggerHammerHit", true);
        m_chargeScale = chargeScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            PaintPlane(enemyScript, Vector3.zero, Vector3.zero, m_chargeScale);
            sprootchAS.Play();
        }
        ColorCube colorCube = other.gameObject.GetComponent<ColorCube>();
        if (colorCube != null)
        {
            colorCube.changeColor();
            sprootchAS.Play();
        }
        SpawnButton spawnButton = other.gameObject.GetComponent<SpawnButton>();
        if (spawnButton != null)
        {
            spawnButton.SpawnWave();
            sprootchAS.Play();
        }
    }

}
