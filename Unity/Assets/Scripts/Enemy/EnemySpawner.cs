using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private List<GameObject> spawn;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < spawn.Count; i++)
            spawn[i].GetComponent<Spawn>().SpawnEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
