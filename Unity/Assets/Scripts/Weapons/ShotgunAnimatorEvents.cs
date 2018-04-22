using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAnimatorEvents : MonoBehaviour {
    
    [SerializeField]
    private Shotgun shotgun;

    [SerializeField]
    private AudioSource gunAS;
    [SerializeField]
    private AudioSource reloadAS;

    public void SetIsRealoading()
    {
        shotgun.IsReloading = true;
    }

    public void SetIsNotRealoading()
    {
        shotgun.IsReloading = false;
    }

    public void PlayShootSound()
    {
        gunAS.Play();
    }

    public void PlayReloadSound()
    {
        reloadAS.Play();
    }

}
