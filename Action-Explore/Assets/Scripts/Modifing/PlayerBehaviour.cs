using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForcePage
{
    public class PlayerBehaviour : Movement
    {
        PlayerInventory _player;
        UIManager _UiSys;


        
        protected override void Start()
        {
            base.Start();
            _player = GetComponent<PlayerInventory>();
            _UiSys = GameObject.Find("UI System").GetComponent<UIManager>();
        }
        protected override void Update()
        {
            health = _player.hp;
            PlayerInput();
            base.Update();
        }

        void PlayerInput()
        {
            float xDirection = Input.GetAxisRaw("Horizontal");
            float yDirection = Input.GetAxisRaw("Vertical");

            MovementInput(new Vector2(xDirection, yDirection));
        }

        protected override void RecieveDamage(DealDamage dmg)
        {
            _player.UpdateHealth(-dmg.damage);
            print(health);
            ReceiveHitColour();
            Invoke("ReceiveHitColour", hitColourTime);

            if (health < 0)
            {
                Death();
            }
        }

        protected override void Death()
        {
            _UiSys.GameOver();
        }

    }

}

