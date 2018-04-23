using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    [SerializeField]
    private GameObject m_spawner;

    public void SpawnWave()
    {
        m_spawner.GetComponent<EnemySpawner>().spawnWave();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Weapon>() != null)
        {
            m_spawner.GetComponent<EnemySpawner>().spawnWave();
        }
    }

}
