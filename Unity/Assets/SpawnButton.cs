using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner m_spawner;

    [SerializeField]
    private Animator animator;

    public void SpawnWave()
    {
        animator.SetTrigger("BtnTrigger");
        m_spawner.spawnWave();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Weapon>() != null)
        {
            SpawnWave();
        }
    }

}
