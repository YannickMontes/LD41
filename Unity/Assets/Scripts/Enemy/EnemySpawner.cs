using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private List<GameObject> spawn;

    [SerializeField]
    private int mobsNumber = 10;

    [SerializeField]
    private GameObject spawnPrefab;

    public ColorCube colorCube;

    private List<GameObject> spawns;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void spawnWave()
    {
        GameObject spawn = Instantiate(spawnPrefab, new Vector3(this.transform.position.x, 0.0f, this.transform.position.z), this.transform.rotation);
        spawn.GetComponent<Spawn>().setSpawnParam(mobsNumber, colorCube.currentMaterial);
        spawn.GetComponent<Spawn>().SpawnEnemies();
    }
}
