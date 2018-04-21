using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    [SerializeField]
    private Color m_color;

    public Color Color
    {
        get
        {
            return m_color;
        }

        set
        {
            m_color = value;
        }
    }

    public void Die()
    {
        Destroy(gameObject, 1.0f);
    }
}
