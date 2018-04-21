using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [SerializeField]
    int mobNumber;

    [SerializeField]
    GameObject mobPrefab;

    [SerializeField]
    Material mobMaterial;

    [SerializeField]
    float spawnDelay;

    [SerializeField]
    float beginTime;

    private GameObject[] Enemies;
    private int currentMobNumber=0;

    public void SpawnEnemies()
    {
        currentMobNumber = 0;
        Enemies = new GameObject[mobNumber];
        InvokeRepeating("SpawnEnemy", beginTime, spawnDelay);
    }

    private void SpawnEnemy()
    {        
        if (currentMobNumber >= mobNumber)
        {
            CancelInvoke();
        }
        else
        {
            GameObject mob = Instantiate(mobPrefab, new Vector3(this.transform.position.x, 0.0f, this.transform.position.z), Quaternion.identity);
            mob.GetComponent<Enemy>().AssignMaterial(mobMaterial);
            Enemies[currentMobNumber]=mob;
        }
        currentMobNumber++;
        
    }

}
