using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    SpriteRenderer sp;

    //Immunity
    protected float immuneTime = 1f;
    protected float lastImmune;

    //Push
    protected Vector3 pushDirection;

    //protected void Start()
    //{
    //    sp = GetComponent<SpriteRenderer>();
    //}

    //All Damagable objects can reiveDamage and get destroyed
    protected virtual void ReceiveDamage(DealDamage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damage;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            HitColour();
            Invoke("HitColour", 1f);

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }

    protected virtual void HitColour()
    {
        sp = GetComponent<SpriteRenderer>();
        if (sp.color == Color.white)
        {
            sp.color = Color.red;
        }
        else
        {
            sp.color = Color.white;
        }
    }
}
