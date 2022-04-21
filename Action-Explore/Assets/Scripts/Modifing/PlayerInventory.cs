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

        
        public float hp
        {
            get
            {
                return health;
            }
        }
        Weapon _weapon;
        public void Start()
        {
            _weapon = GetComponent<Weapon>();
        }

        public void UpdateHealth(float valueToAdd)
        {
            health += valueToAdd;
        }

        public void UpdateAmmo(int valueToAdd)
        {
            _weapon.AddAmmo(valueToAdd);
        }
    }

}
