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

    public GameObject SplatPrefab
    {
        get
        {
            return m_splatPrefab;
        }

        set
        {
            m_splatPrefab = value;
        }
    }

    public Sprite SplatSprite
    {
        get
        {
            return splatSprite;
        }

        set
        {
            splatSprite = value;
        }
    }


    #region Private

    [SerializeField]
    protected string m_name;

    [SerializeField]
    protected Sprite splatSprite;

    [SerializeField]
    protected GameObject m_splatPrefab;

    #endregion
}
