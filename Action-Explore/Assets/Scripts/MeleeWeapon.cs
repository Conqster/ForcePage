using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Collidable
{
    public int damageRate = 1;
    public float pushForce = 2f;

    //Upgrade
    public int weaponLevel = 0;
    SpriteRenderer sp;


    //Swing
    private Animator anim;
    float cooldown = 0.5f;
    float lastSwing;

    protected override void Start()
    {
        base.Start();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print("Action !!!!!!!!");
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }


    protected override void OnCollide(Collider2D col)
    {
        if(col.tag == "Damagable")
        {
            //Debug.Log(col.name);

            DealDamage dmg = new DealDamage();
            dmg.damage = damageRate;
            dmg.origin = transform.position;
            dmg.pushForce = pushForce;

            col.SendMessage("ReceiveDamage", dmg); //definitely need to change this 

        }
       // return; // to return avoiding errors
    }
    void Swing()
    {
        //Debug.Log("Swing");
        anim.SetTrigger("Swing");
    }
}
