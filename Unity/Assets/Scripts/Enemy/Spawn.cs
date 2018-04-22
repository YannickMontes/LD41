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

    [SerializeField]
    float lifeSpawn;


    private int currentMobNumber=0;

    public void SpawnEnemies()
    {
        currentMobNumber = 0;
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
           
            GameObject mob = Instantiate(mobPrefab, new Vector3(this.transform.position.x, 0.0f, this.transform.position.z), this.transform.rotation);
            mob.GetComponent<Enemy>().AssignMaterial(mobMaterial);         
            mob.transform.SetParent(GameManager.instance.mobs.transform);
            mob.GetComponent<Enemy>().origin = this.gameObject;
            mob.GetComponent<Enemy>().beginTime = beginTime;
            mob.GetComponent<Enemy>().lifeSpawn = lifeSpawn;

        }
        currentMobNumber++;
        
    }



}
