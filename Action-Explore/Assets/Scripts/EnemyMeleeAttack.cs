using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : Collidable
{
    //Damage
    [SerializeField] int damageRate = 1;
    [SerializeField] float pushForce = 7;

    protected override void OnCollide(Collider2D col)
    {
        base.OnCollide(col);
        if(col.tag == "Player" && col.name == "Player")
        {
            DealDamage dmg = new DealDamage();
            dmg.damage = damageRate;
            dmg.origin = transform.position;
            dmg.pushForce = pushForce;

            col.SendMessage("ReceiveDamage", dmg);
        }
    }
}
