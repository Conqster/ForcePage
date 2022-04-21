using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class HealthPickUp : Collectable
    {
        [SerializeField] float healthPickValue = 50;
        PlayerInventory _playerInventory;

        
        protected override void GiveItem()
        {
            _playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
            //print("okay");
            // _playerInventory.UpdateHealth(healthPickValue);
            //_player.hp += healthPickValue;
            //_player.UpdateHealth(healthPickValue);
            _playerInventory.UpdateHealth(healthPickValue);
            //_player.UpdateHealth(healthPickValue);
            //Manager.instance.hp += healthPickValue;
        }

    }

}
