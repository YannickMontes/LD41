using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Weapon(string name)
    {
        m_name = name;
    }


    public abstract void HitEnemy(); 

    #region Private

    [SerializeField]
    protected string m_name;

    [SerializeField]
    protected GameObject m_spritePrefab;

    #endregion
}
