using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    [SerializeField]
    protected List<GameObject> selfReferences;

    [SerializeField]
    protected Material material;

<<<<<<< HEAD
=======
    public Material Material
    {
        get
        {
            return material;
        }

        set
        {
            material = value;
        }
    }

>>>>>>> 320eefc17befbb5c463e9167dddfdff7084a0555
    private void Start()
    {
        if(selfReferences.Count > 0)
            this.material = selfReferences[0].GetComponent<MeshRenderer>().material;

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
}
