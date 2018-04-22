using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSplasher : MonoBehaviour {

    [SerializeField]
    private List<ParticleSystem> m_colorsToChange;

    [SerializeField]
    private GameObject splatPreab;

    [SerializeField]
    private Sprite splatSpriteV3;

    [SerializeField]
    private Sprite splatSpriteV2;

    private Color m_color;

    public GameObject SplatPreab
    {
        get
        {
            return splatPreab;
        }

        set
        {
            splatPreab = value;
        }
    }

    public Sprite SplatSpriteV3
    {
        get
        {
            return splatSpriteV3;
        }

        set
        {
            splatSpriteV3 = value;
        }
    }

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

    public Sprite SplatSpriteV2
    {
        get
        {
            return splatSpriteV2;
        }

        set
        {
            splatSpriteV2 = value;
        }
    }

    public void SetColor(Color color)
    {
        foreach (ParticleSystem particleSys in m_colorsToChange)
        {
            ParticleSystem.MainModule main = particleSys.main;
            main.startColor = color;        
        }
        m_color = color;
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
