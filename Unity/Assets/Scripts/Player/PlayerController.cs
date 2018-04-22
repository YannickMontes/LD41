using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private List<Weapon> m_weapons = new List<Weapon>();

    [SerializeField]
    private GameObject mobs;

    private Weapon m_currentWeapon = null;

    private bool m_mouseButtonHeldDown = false;

    private float currentChargeScale;
    private float lerpTimeValue;

	// Use this for initialization
	void Start ()
    {
        if (m_weapons.Count > 0)
        {
            m_currentWeapon = m_weapons[0];
            currentChargeScale = m_currentWeapon.MinScaleHit;
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
            CastWeapon();
        }
        if (InputSwitchWeapon())
        {
            SwitchWeapon();
        }
        if (InputScreenShot())
        {
            changeMobsStatus();
            this.GetComponent<ArtExport>().exportArtToPNG();
            changeMobsStatus();
        }
        LerpCurrentChargeScale();
    }

    private void LerpCurrentChargeScale()
    {
        if (m_mouseButtonHeldDown)
        {
            if (currentChargeScale == m_currentWeapon.MinScaleHit)
                lerpTimeValue = Time.deltaTime;
            currentChargeScale = Mathf.Lerp(m_currentWeapon.MinScaleHit, m_currentWeapon.MaxScaleHit, lerpTimeValue/m_currentWeapon.ChargeTime);
            lerpTimeValue += Time.deltaTime;
        }
        else
        {
            lerpTimeValue = 0.0f;
            currentChargeScale = m_currentWeapon.MinScaleHit;
        }
    }

    private void CastWeapon()
    {
        m_currentWeapon.CastWeaponSkill(currentChargeScale);
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
        currentChargeScale = m_currentWeapon.MinScaleHit;
    }

    private bool InputHit()
    {
        if (Input.GetMouseButton(0))
        {
            if (!m_currentWeapon.CanChargeAttack)
            {
                m_mouseButtonHeldDown = false;
                return true;
            }
            else
            {
                m_mouseButtonHeldDown = true;
                return false;
            }
        }
        else
        {
            if (!m_currentWeapon.CanChargeAttack)
            {
                m_mouseButtonHeldDown = false;
                return false;
            }
            else
            {
                if (m_mouseButtonHeldDown)
                {
                    m_mouseButtonHeldDown = false;
                    return true;
                }
                else
                    return false;
            }
        }
    }

    private bool InputSwitchWeapon()
    {
        if (m_currentWeapon as Shotgun != null && (m_currentWeapon as Shotgun).IsReloading)
            return false;
        return Input.GetAxis("Mouse ScrollWheel") != 0.0f;
    }

    private bool InputScreenShot()
    {
        return Input.GetKeyDown(KeyCode.P);
    }

    private void changeMobsStatus()
    {
        this.gameObject.SetActive(!gameObject.activeSelf);
        mobs.SetActive(!mobs.activeSelf);
    }
}
