using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private List<Weapon> m_weapons = new List<Weapon>();

    private Weapon m_currentWeapon = null;

	// Use this for initialization
	void Start ()
    {
        if (m_weapons.Count > 0)
            m_currentWeapon = m_weapons[0];
	}

    void Update()
    {
        if (InputHit())
        {
            HitWeapon();
        }
    }

    private void HitWeapon()
    {
        m_currentWeapon.HitEnemy();
    }

    private bool InputHit()
    {
        return Input.GetMouseButtonDown(0);
    }
}
