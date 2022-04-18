using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class EnemyBullet : Collidable
    {
        [SerializeField] int damage;
        [SerializeField] GameObject attacher;



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
