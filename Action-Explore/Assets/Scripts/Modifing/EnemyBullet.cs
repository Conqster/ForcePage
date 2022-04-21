using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class EnemyBullet : Collidable
    {
        [Range(10f, 90f)]
        [SerializeField] float damage;



        protected override void OnCollide(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                DealDamage dmg = new DealDamage();
                dmg.damage = damage;

                collision.SendMessage("RecieveDamage", dmg);

                Destroy(gameObject);
            }

            if (collision.tag == "Projectiles" || collision.tag == "Obstacle")
            {
                Destroy(gameObject);
            }
        }
    }

}
