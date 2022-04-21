using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class AmmoPickUp : Collectable
    {
        [SerializeField] int ammoPickValue = 1;


        protected override void GiveItem()
        {
            //_playerInvetory.UpdateAmmo(ammoValue);
            //_player.hp += healthPickValue;
        }
    }

}
