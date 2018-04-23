using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    [SerializeField]
    private GameObject m_spawner;

    [SerializeField]
    private Animator animator;

    public void SpawnWave()
    {
        animator.SetTrigger("BtnTrigger");
        m_spawner.GetComponent<EnemySpawner>().spawnWave();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Weapon>() != null)
        {
            SpawnWave();
        }
    }

}
