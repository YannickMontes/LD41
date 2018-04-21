using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Weapon(string name)
    {
        m_name = name;
    }

    public abstract void CastWeaponSkill();

    public GameObject SplatPrefab
    {
        get
        {
            return m_splatPrefab;
        }

        set
        {
            m_splatPrefab = value;
        }
    }

    public Sprite SplatSprite
    {
        get
        {
            return splatSprite;
        }

        set
        {
            splatSprite = value;
        }
    }

    public Animator Animator
    {
        get
        {
            return m_animator;
        }

        set
        {
            m_animator = value;
        }
    }

    protected void LaunchSplashParticles(Enemy enemyScript)
    {
        GameObject particles = Instantiate(m_particlesPrefab, enemyScript.transform.position, Quaternion.identity);
        particles.GetComponent<ParticlesSplasher>().SetColor(enemyScript.GetColor());
        Destroy(particles, 3.0f);
    }

    protected void PaintPlane(Enemy enemyScript, Vector3 direction)
    {
        Vector3 whereToSpawn = enemyScript.transform.position;
        Quaternion whereToLookSplatter = Quaternion.identity;
        if (direction != Vector3.zero)
        {
            direction = new Vector3(direction.x, 0.0f, direction.z).normalized;
            whereToSpawn = enemyScript.transform.position + direction * ((splatSprite.rect.height / 2) /100);
            whereToLookSplatter = Quaternion.identity;
        }

        whereToSpawn = new Vector3(whereToSpawn.x, 0.0f, whereToSpawn.z);
        GameObject spriteObject = Instantiate(m_splatPrefab, whereToSpawn, whereToLookSplatter);
        SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = enemyScript.GetColor();
        spriteRenderer.sprite = splatSprite;
        spriteObject.transform.LookAt(spriteObject.transform.position + Vector3.up);

        LaunchSplashParticles(enemyScript);

        enemyScript.Die();
    }


    #region Private

    [SerializeField]
    protected string m_name;

    [SerializeField]
    protected Sprite splatSprite;

    [SerializeField]
    protected GameObject m_splatPrefab;

    [SerializeField]
    protected Animator m_animator;

    [SerializeField]
    protected GameObject m_particlesPrefab;

    #endregion
}
