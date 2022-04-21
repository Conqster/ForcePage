using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForcePage
{
    public class BulletBehaviour : Collidable
    {
        [Range(5f, 50f)]
        [SerializeField] float damage = 40f;

        

        protected override void OnCollide(Collider2D collision)
        {
            if(collision.tag == "Damagable")
            {
                DealDamage dmg = new DealDamage();
                dmg.damage = damage;

                collision.SendMessage("RecieveDamage", dmg);

                Destroy(gameObject);
            }

            if(collision.tag == "Projectiles" || collision.tag == "Obstacle")
            {
                Destroy(gameObject);
            }
        }
    }

}
