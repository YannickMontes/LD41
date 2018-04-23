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
    private bool isCharging;

    public Weapon CurrentWeapon
    {
        get
        {
            return m_currentWeapon;
        }

        set
        {
            m_currentWeapon = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        if (m_weapons.Count > 0)
        {
            CurrentWeapon = m_weapons[0];
            currentChargeScale = CurrentWeapon.MinScaleHit;
            foreach (Weapon weapon in m_weapons)
            {
                if (weapon != CurrentWeapon)
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
        int switchWeaponInput = InputSwitchWeapon();
        if (switchWeaponInput != 0)
        {
            SwitchWeapon(switchWeaponInput);
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
            if (currentChargeScale == CurrentWeapon.MinScaleHit)
                lerpTimeValue = Time.deltaTime;
            currentChargeScale = Mathf.Lerp(CurrentWeapon.MinScaleHit, CurrentWeapon.MaxScaleHit, lerpTimeValue/CurrentWeapon.ChargeTime);
            if (CurrentWeapon.GetType() == typeof(Hammer) && !isCharging) {
                CurrentWeapon.Animator.SetTrigger("TriggerHammerCharge");
            }
            ShakeScreen.Instance.SetShakingActive(true);
            ShakeScreen.Instance.SetShakingStrength(Mathf.Clamp(currentChargeScale - 1.25f, 0f, CurrentWeapon.MaxScaleHit));
            lerpTimeValue += Time.deltaTime;
            isCharging = true;
        }
        else
        {
            lerpTimeValue = 0.0f;
            currentChargeScale = CurrentWeapon.MinScaleHit;
            ShakeScreen.Instance.SetShakingActive(false);
            isCharging = false;
        }
    }

    private void CastWeapon()
    {
        CurrentWeapon.CastWeaponSkill(currentChargeScale);
    }

    private void SwitchWeapon(int switchDirection)
    {
        int currentIndex = m_weapons.IndexOf(CurrentWeapon);
        currentIndex += switchDirection;
        if (currentIndex < 0) {
            currentIndex = m_weapons.Count - 1;
        }
        currentIndex = currentIndex % m_weapons.Count;

        CurrentWeapon.gameObject.SetActive(false);
        CurrentWeapon = m_weapons[currentIndex];
        CurrentWeapon.gameObject.SetActive(true);
        currentChargeScale = CurrentWeapon.MinScaleHit;
    }

    private bool InputHit()
    {
        if (CurrentWeapon.CanChargeAttack)
        {
            if (Input.GetMouseButton(0))
            {
                m_mouseButtonHeldDown = true;
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
        else
        {
            return Input.GetMouseButtonDown(0);
        }

        if (Input.GetMouseButton(0))
        {
            if (!CurrentWeapon.CanChargeAttack)
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
            if (!CurrentWeapon.CanChargeAttack)
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

    private int InputSwitchWeapon()
    {
        if (CurrentWeapon as Shotgun != null && (CurrentWeapon as Shotgun).IsReloading)
            return 0;
        float value = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Approximately(0.0f, value)) {
            return 0;
        } else if (value < 0f) {
            return -1;
        } else {
            return 1;
        }
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
