using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Collectable : Collidable
    {
        protected PlayerInventory _playerInventory;


        protected override void Start()
        {
            base.Start();
            _playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        }



        protected override void OnCollide(Collider2D collision)
        {
            
            if (collision.name == "Player")
            {
                DestroyOnGive();
                GiveItem();
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
