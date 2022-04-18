using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Collectable : Collidable
    {
        protected PlayerInventory _playerInvetory;

        protected override void OnCollide(Collider2D victim)
        {

            _playerInvetory = victim.gameObject.GetComponent<PlayerInventory>();
            //print(victim);
                if(_playerInvetory != null)
                {
                    GiveItem();
                    DestroyOnGive();
                }
           
        }
        

        protected virtual void GiveItem()
        {

        }

        protected void DestroyOnGive()
        {
            Destroy(gameObject);
        }
    }

}
