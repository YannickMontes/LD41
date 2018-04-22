using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Weapon(string name)
    {
        m_name = name;
    }

    public abstract void CastWeaponSkill(float chargeScale);

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

    public bool CanChargeAttack
    {get
        {
            return m_canChargeAttack;
        }
        set
        {
            m_canChargeAttack = value;
        }
    }

    public float MinScaleHit
    {
        get
        {
            return minScaleHit;
        }

        set
        {
            minScaleHit = value;
        }
    }

    public float MaxScaleHit
    {
        get
        {
            return maxScaleHit;
        }

        set
        {
            maxScaleHit = value;
        }
    }

    public float ChargeTime
    {
        get
        {
            return chargeTime;
        }

        set
        {
            chargeTime = value;
        }
    }

    protected void LaunchSplashParticles(Enemy enemyScript, Vector3 forwardDir)
    {
        GameObject particles = Instantiate(m_particlesPrefab, enemyScript.transform.position, Quaternion.identity);
        particles.transform.forward = forwardDir;
        particles.transform.position += Vector3.up * 0.5f;
        particles.GetComponent<ParticlesSplasher>().SetColor(enemyScript.GetColor());
        Destroy(particles, 3.0f);
    }

    protected void PaintPlane(Enemy enemyScript, Vector3 groundHit, Vector3 direction, float chargeScale)
    {
        //V1 Splash 
        SplashConstantSprite(enemyScript, groundHit, direction, chargeScale);

        //V2 Splash
        SplashWithParticlesCollision(enemyScript, groundHit, direction);
    }

    private void SplashConstantSprite(Enemy enemyScript, Vector3 groundHit, Vector3 direction, float chargeScale)
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

        spriteObject.transform.localScale *= chargeScale;
    }

    private void SplashWithParticlesCollision(Enemy enemyScript, Vector3 groundHit, Vector3 direction)
    {
        Vector3 forwardDirPart = Vector3.forward;

        if (this as Shotgun != null)
        {
            forwardDirPart = direction;
        }

        LaunchSplashParticles(enemyScript, forwardDirPart);

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

    [SerializeField]
    protected bool m_canChargeAttack;

    [SerializeField]
    protected float minScaleHit = 1.0f;

    [SerializeField]
    protected float maxScaleHit = 3.0f;

    [SerializeField]
    protected float chargeTime = 1.0f;

    public static int orderInLayer = 1;

    #endregion
}
