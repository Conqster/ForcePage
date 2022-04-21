using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class HealthPickUp : Collectable
    {
        [SerializeField] float healthPickValue = 50;

        
        protected override void GiveItem()
        {
            _playerInventory.UpdateHealth(healthPickValue);
        }

    }

}
