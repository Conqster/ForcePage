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
        [SerializeField] int health;
        Weapon _weapon;
        public void Start()
        {
            _weapon = GetComponent<Weapon>();
        }
        public void UpdateHealth(int valueToAdd)
        {
            health += valueToAdd;
        }

        public void UpdateAmmo(int valueToAdd)
        {
            _weapon.AddAmmo(valueToAdd);
        }
    }

}
