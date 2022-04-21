using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    enum Weapons { Gun, Sword};
    public class Weapon : MonoBehaviour
    {
        [SerializeField] GameObject Bullet; // prefab for bullet 
        [SerializeField] Transform bulletPoint, attackerTran;

        float projectileSpeed = 5;
        [SerializeField] int bulletLeft, magazineSize;
        //time to be able to shot the next shot
        [SerializeField] float timeBetweenShooting = 1;
        //bool to allow shot 
        [SerializeField] bool allowShot, attack;
        //reload time

        Weapons currentWeapon;
        PlayerInventory _playerInventory;
        

        // its going to be good to have a switch case to either shoot or swing melee weapon 
        protected void Start()
        {
            //ResetShot();
            allowShot = true;
            attackerTran = GetComponent<Transform>();
            _playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
            AmmoOnEquip();
        }

        
        private void Update()
        {
            bulletLeft = _playerInventory.bulletLeft;
            CurrentWeapon();
            GetInputs();
            Attack();
        }

        void AmmoOnEquip()
        {
            magazineSize = _playerInventory.magSize; // gets the gun ammmo size 
            _playerInventory.UpdateAmmo(magazineSize); // sets the bulletLeft to gun ammo size
        }
        void CurrentWeapon()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                currentWeapon = Weapons.Gun;
            }
            else if (Input.GetKey(KeyCode.X))
            {
                currentWeapon = Weapons.Sword;
            }
        }
        void GetInputs()
        {
            attack = Input.GetKey(KeyCode.Space);
        }

        void Attack()
        {
            if(currentWeapon == Weapons.Sword)
            {
                Melee();
            }
            else
            {
                ArmSafetyOff();
            }
        }

        void Melee()
        {
            if(attack)
            {
                 print("trying to swing my sword");
            }
        }
        void ArmSafetyOff()
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


            Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
            if(attackerTran.localScale.x == -1)
            {
                bulletRb.velocity = - bulletPoint.transform.right * projectileSpeed;
            }
            else
            {
                bulletRb.velocity = bulletPoint.transform.right * projectileSpeed;
            }

            //bulletLeft --;
            _playerInventory.UpdateAmmo(-1);
            Invoke("ResetShot", timeBetweenShooting);
        }


        //might change to a bool return method with some bit of logics 
        void ResetShot()
        {
             allowShot = true;
        }

     
    }

}
