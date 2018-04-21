using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private GameObject spawn;

	// Use this for initialization
	void Start () {
        spawn.GetComponent<Spawn>().SpawnEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
