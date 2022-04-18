using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] GameObject Bullet;
        [SerializeField] Transform bulletPoint, attackerTran;

        float projectileSpeed = 5;


        private void Start()
        {
            attackerTran = GetComponent<Transform>();
        }
        public void FireShot()
        {
            if (Bullet != null)
            {
                GameObject newBullet = Instantiate(Bullet, bulletPoint.position, Quaternion.identity);
                print("you are out");
                Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
                if (attackerTran.localScale.x == -1)
                {
                    bulletRb.velocity = -bulletPoint.transform.right * projectileSpeed;
                }
                else
                {
                    bulletRb.velocity = bulletPoint.transform.right * projectileSpeed;
                }
            }
        }

    }

}
