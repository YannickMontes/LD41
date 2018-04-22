using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    [SerializeField]
    protected List<GameObject> selfReferences;

    [SerializeField]
    protected Material material;

    [SerializeField]
    GameObject targetPrefab;

    GameObject target = null;

    float width = 50;
    float height = 60;

    Movement movement;

    private void Start()
    {
        if(selfReferences.Count > 0)
            this.material = selfReferences[0].GetComponent<MeshRenderer>().material;

        this.movement = this.GetComponent<Movement>();

        target = Instantiate(targetPrefab, new Vector3(this.transform.position.x, 0.0f, this.transform.position.z), Quaternion.identity);
        target.transform.position = new Vector3(UnityEngine.Random.Range(-width / 2, width / 2), 0, UnityEngine.Random.Range(-height / 2, height / 2));
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
        Destroy(target);
        Destroy(gameObject);
    }

    private void Update()
    {
        this.movement.Move(target);
    }
}
