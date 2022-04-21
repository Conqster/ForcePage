using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForcePage
{
    public class PlayerInventory : MonoBehaviour
    {
        //using this to store 
        // health 
        // ammos
        [Range(0f, 100f)]
        [SerializeField] float health = 90;
        [Range(0, 20)]
        [SerializeField] int magazineSize;
        int bulletsInStore;
        
        public float hp
        {
            get
            {
                return health;
            }
        }

        public int bulletLeft
        {
            get
            {
                return bulletsInStore;
            }
        }

        public int magSize
        {
            get
            {
                return magazineSize;
            }
        }
        

        public void UpdateHealth(float valueToAdd)
        {
            if (health <= 100) // ***playerMaxHealth was changed from PlayerMaxHealth() & PlayerHp from playerHealth
            {
                //print("i'm been called");
                // to avoid getting health than max health
                float healthNeeded = 100 - health; // ***playerMaxHealth was changed from PlayerMaxHealth() & PlayerHp from playerHealth
                if (healthNeeded > valueToAdd) // if what player needs is more that health pickup
                {
                    health += valueToAdd; // PlayerHp from playerHealth
                }
                else
                {
                    health += healthNeeded; // if the pick up is more than what the player needs just give them what they need //& PlayerHp from playerHealth
                }
            }
        }

        public void UpdateAmmo(int valueToAdd)
        {
            int ammoNeed = magazineSize - bulletLeft;
            if (ammoNeed > valueToAdd)
            {
                bulletsInStore += valueToAdd;
            }
            else //if (ammoNeed < valueToAdd)
            {
                bulletsInStore += ammoNeed;
            }
        }
    }

}
