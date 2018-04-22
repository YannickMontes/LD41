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

    protected void LaunchSplashParticles(Enemy enemyScript, Vector3 upDir)
    {
        GameObject particles = Instantiate(m_particlesPrefab, enemyScript.transform.position, Quaternion.identity);
        particles.transform.up = upDir;
        particles.GetComponent<ParticlesSplasher>().SetColor(enemyScript.GetColor());
        Destroy(particles, 3.0f);
    }

    protected void PaintPlane(Enemy enemyScript, Vector3 groundHit, Vector3 direction)
    {
        //V1 Splash 
        SplashConstantSprite(enemyScript, groundHit, direction);

        //V2 Splash
        SplashWithParticlesCollision(enemyScript, groundHit, direction);
    }

    private void SplashConstantSprite(Enemy enemyScript, Vector3 groundHit, Vector3 direction)
    {
        Vector3 whereToSpawn = enemyScript.transform.position;
        Quaternion whereToLookSplatter = Quaternion.identity;

        whereToSpawn = new Vector3(whereToSpawn.x, 0.0f, whereToSpawn.z) + direction.normalized * 5.0f;
        GameObject spriteObject = Instantiate(m_splatPrefab, whereToSpawn, whereToLookSplatter);
        SpriteRenderer spriteRenderer = spriteObject.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sortingOrder = orderInLayer++;
        spriteRenderer.color = enemyScript.GetColor();
        spriteRenderer.sprite = splatSprite;

        GameObject splatterParent = GameObject.Find("Splatters");
        if (splatterParent == null)
        {
            splatterParent = new GameObject("Splatters");
            splatterParent.transform.position = Vector3.zero;
            splatterParent.transform.rotation = Quaternion.identity;
        }
        spriteObject.transform.SetParent(splatterParent.transform);

        if (direction != Vector3.zero)
        {
            spriteObject.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void SplashWithParticlesCollision(Enemy enemyScript, Vector3 groundHit, Vector3 direction)
    {
        Vector3 upDirPart = Vector3.up;

        if (this as Shotgun != null)
        {
            upDirPart = direction;
        }

        LaunchSplashParticles(enemyScript, upDirPart);

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

    public static int orderInLayer = 1;

    #endregion
}
