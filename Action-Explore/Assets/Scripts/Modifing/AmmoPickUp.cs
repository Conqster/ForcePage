using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class AmmoPickUp : Collectable
    {
        [SerializeField] int ammoValue = 1;


        protected override void GiveItem()
        {
            _playerInvetory.UpdateAmmo(ammoValue);
        }
    }

}
