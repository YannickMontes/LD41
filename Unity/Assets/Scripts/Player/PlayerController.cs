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
        {
            m_currentWeapon = m_weapons[0];
            foreach (Weapon weapon in m_weapons)
            {
                if (weapon != m_currentWeapon)
                {
                    weapon.gameObject.SetActive(false);
                }
            }
        }
    }

    void Update()
    {
        if (InputHit())
        {
            HitWeapon();
        }
        if (InputSwitchWeapon())
        {
            SwitchWeapon();
        }
    }

    private void HitWeapon()
    {
        m_currentWeapon.CastWeaponSkill();
    }

    private void SwitchWeapon()
    {
        int currentIndex = m_weapons.IndexOf(m_currentWeapon);
        if (currentIndex >= m_weapons.Count - 1)
            currentIndex = 0;
        else
            currentIndex++;
        m_currentWeapon.gameObject.SetActive(false);
        m_currentWeapon = m_weapons[currentIndex];
        m_currentWeapon.gameObject.SetActive(true);
    }

    private bool InputHit()
    {
        return Input.GetMouseButtonDown(0);
    }

    private bool InputSwitchWeapon()
    {
        return Input.GetKeyDown(KeyCode.S);
    }
}
