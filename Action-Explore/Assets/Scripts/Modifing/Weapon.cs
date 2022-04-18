using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] GameObject Bullet; // prefab for bullet 
        [SerializeField] Transform bulletPoint, attackerTran;

        PlayerInventory _playerInventory;
        Vector2 projetilePos;
        float projectileSpeed = 5 , projectileDeltaSpeed;
        //bullet left in the gun 
        [SerializeField] int bulletLeft;
        //magazine size the maximum amount of bullet in a gun 
        int magazineSize = 10;
        //time to be able to shot the next shot
        [SerializeField] float timeBetweenShooting = 1;
        //bool to allow shot 
        [SerializeField] bool allowShot, attack;
        //reload time


        // its going to be good to have a switch case to either shoot or swing melee weapon 
        protected void Start()
        {
            //bulletLeft = magazineSize;
            bulletLeft = magazineSize;
            //ResetShot();
            allowShot = true;
            attackerTran = GetComponent<Transform>();
        }

        
        private void Update()
        {
            //projectile change with time
            GetInputs();
            ArmSafety();
            //Debug.LogFormat("bullet left - {0}, magazine size - {1}", bulletLeft, magazineSize);
        }


        void GetInputs()
        {
            attack = Input.GetKey(KeyCode.Space);
        }

        void ArmSafety()
        {
            if (allowShot && attack && bulletLeft > 0)
            {
                Shoot();
            }
        }
        void Shoot()
        {
            allowShot = false;

            GameObject newBullet = Instantiate(Bullet, bulletPoint.position, Quaternion.identity);

            //newBullet.transform.Translate (bulletPoint.transform.right * Time.deltaTime);

            Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
            if(attackerTran.localScale.x == -1)
            {
                bulletRb.velocity = - bulletPoint.transform.right * projectileSpeed;
            }
            else
            {
                bulletRb.velocity = bulletPoint.transform.right * projectileSpeed;
            }

            bulletLeft --;
            Invoke("ResetShot", timeBetweenShooting);
        }


        //might change to a bool return method with some bit of logics 
        void ResetShot()
        {
             allowShot = true;
        }

        public void AddAmmo(int ammo)
        {
            int ammoNeed = magazineSize - bulletLeft;
              if(ammoNeed > ammo)
                 {
                   bulletLeft += ammo;
                 }
              else if (ammoNeed < ammo)
                 {
                   bulletLeft += ammoNeed;
                 }
        }
    }

}
