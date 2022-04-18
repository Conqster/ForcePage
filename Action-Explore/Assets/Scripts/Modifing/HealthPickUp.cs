using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class HealthPickUp : Collectable
    {
        [SerializeField] int healthValue = 1;


        protected override void GiveItem()
        {
            _playerInvetory.UpdateHealth(healthValue);
        }
    }

}
