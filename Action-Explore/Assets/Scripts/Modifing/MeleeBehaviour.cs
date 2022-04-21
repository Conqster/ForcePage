using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForcePage
{
    public class MeleeBehaviour : Collidable
    {
        [Range(1f, 20f)]
        [SerializeField] float damage = 1f;
        float cooldown = 1f;

        int dealtTime;


        protected override void Update()
        {
            base.Update();
            //Debug.LogFormat("attack done - {0}, cooldown - {1} ", dealtTime, cooldown);
            if(dealtTime > 0)
            {
                cooldown -= Time.deltaTime;
                if (cooldown < 0)
                {
                    dealtTime = 0;
                    cooldown = 1f;
                }
            }
        }

       
        protected override void OnCollide(Collider2D collision)
        {

            if(collision.tag == "Damagable" && dealtTime == 0)
            {
                dealtTime++;
                DealDamage dmg = new DealDamage();
                dmg.damage = damage;

                collision.SendMessage("RecieveDamage", dmg);
            }
        }
    }
}
