using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesCollisionHandler : MonoBehaviour {

    private List<ParticleCollisionEvent> particlesCollisionEvents;

	// Use this for initialization
	void Start () {
        particlesCollisionEvents = new List<ParticleCollisionEvent>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log(other.name);
        ParticlesSplasher splasher = other.GetComponentInParent<ParticlesSplasher>();
        if (splasher != null)
        {
            ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
            int nbCollisionEvent = particleSystem.GetCollisionEvents(gameObject, particlesCollisionEvents);

            int i = 0;

            while (i < nbCollisionEvent)
            {
                Sprite sprite = splasher.SplatSpriteV3;
                Vector3 whereToSpawn = new Vector3(particlesCollisionEvents[i].intersection.x, 0.0f, particlesCollisionEvents[i].intersection.z);
                GameObject splat = Instantiate(splasher.SplatPreab, whereToSpawn, Quaternion.identity);
                SpriteRenderer spriteRenderer = splat.GetComponentInChildren<SpriteRenderer>();
                spriteRenderer.sortingOrder = Weapon.orderInLayer++;
                spriteRenderer.color = splasher.Color;
                spriteRenderer.sprite = splasher.SplatSpriteV3;

                GameObject splatterParent = GameObject.Find("Splatters");
                if (splatterParent == null)
                {
                    splatterParent = new GameObject("Splatters");
                    splatterParent.transform.position = Vector3.zero;
                    splatterParent.transform.rotation = Quaternion.identity;
                }
                splat.transform.SetParent(splatterParent.transform);
                i++;
            }
        }
    }
}
