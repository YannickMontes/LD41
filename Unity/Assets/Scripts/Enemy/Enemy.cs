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

    [SerializeField]
    private GameObject map;

    float width;
    float height;

    public float beginTime;    
    public float lifeSpawn = 60f;

    public GameObject origin;

    Movement movement;

    public bool canMove = true;


    bool moveInCanvas = true;

    private void Start()
    {
        if(selfReferences.Count > 0)
            this.material = selfReferences[0].GetComponent<MeshRenderer>().material;

        this.movement = this.GetComponent<Movement>();

        width = map.transform.localScale.x;
        height = map.transform.localScale.z;
        target = Instantiate(targetPrefab, new Vector3(this.transform.position.x, 0.0f, this.transform.position.z), Quaternion.identity);
        target.transform.position = new Vector3(UnityEngine.Random.Range(-width / 2, width / 2), 0, UnityEngine.Random.Range(-height / 2, height / 2));
        target.transform.SetParent(GameManager.instance.targets.transform);

        Invoke("runAway", lifeSpawn + beginTime);
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
        if (canMove) {
            this.movement.Move(target, moveInCanvas);

            if (!moveInCanvas && Vector3.Distance(origin.transform.position, this.transform.position) < 2.0f) {
                this.Die();
            }
        }
    }

    public void returnToOrigin()
    {
        target.transform.position = origin.transform.position;
    }
 
   public void runAway()
    {
        moveInCanvas = false;
        returnToOrigin();
    }
}
