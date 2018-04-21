using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSplasher : MonoBehaviour {

    [SerializeField]
    private List<ParticleSystem> m_colorsToChange;

    public void SetColor(Color color)
    {
        foreach (ParticleSystem particleSys in m_colorsToChange)
        {
            ParticleSystem.MainModule main = particleSys.main;
            main.startColor = color;        
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
