using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForcePage
{
    public class PlayerBehaviour : Movement
    {
        PlayerInventory _player;


        
        protected override void Start()
        {
            base.Start();
            _player = GetComponent<PlayerInventory>();
        }
        protected override void Update()
        {
            health = _player.hp;
            //health = _player.hp;
            PlayerInput();
            base.Update();
        }

        void PlayerInput()
        {
            float xDirection = Input.GetAxisRaw("Horizontal");
            float yDirection = Input.GetAxisRaw("Vertical");

            MovementInput(new Vector2(xDirection, yDirection));
        }

        public void UpdateHealth(float valueToAdd)
        {
            print("tryingg to nupdate");
            //health += valueToAdd;
        }

    }

}

