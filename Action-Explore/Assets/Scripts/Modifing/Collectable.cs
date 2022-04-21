using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Collectable : Collidable
    {
        //protected PlayerBehaviour _player;


        
        protected override void OnCollide(Collider2D collision)
        {
            //print(collision);
            //_player = GetComponent<PlayerBehaviour>();
            if (collision.name == "Player")
            {
                DestroyOnGive();
                GiveItem();
            }
            //_playerInvetory = victim.gameObject.GetComponent<PlayerInventory>();
            ////print(victim);
            //    if(_playerInvetory != null)
            //    {
            //        GiveItem();
            //        DestroyOnGive();
            //    }
           
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
