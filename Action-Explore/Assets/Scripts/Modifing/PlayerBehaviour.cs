using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForcePage
{
    public class PlayerBehaviour : Movement
    {
        protected override void Update()
        {
            PlayerInput();
            base.Update();
        }

        void PlayerInput()
        {
            float xDirection = Input.GetAxisRaw("Horizontal");
            float yDirection = Input.GetAxisRaw("Vertical");

            MovementInput(new Vector2(xDirection, yDirection));
        }


    }

}

