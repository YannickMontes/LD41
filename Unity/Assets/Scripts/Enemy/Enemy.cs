using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    [SerializeField]
    protected List<GameObject> selfReferences;

    [SerializeField]
    protected Material material;

    Movement movement;

    private void Start()
    {
        if(selfReferences.Count > 0)
            this.material = selfReferences[0].GetComponent<MeshRenderer>().material;

        this.movement = this.GetComponent<Movement>();
    }

    public void AssignMaterial(Material material)
    {
        this.material = material;
        foreach (GameObject selfref in selfReferences)
        {
            selfref.GetComponent<MeshRenderer>().material = material;
        }
    }

    public Color GetColor()
    {
        return this.material.GetColor("_EmissionColor");
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        this.movement.Move();
    }
}
