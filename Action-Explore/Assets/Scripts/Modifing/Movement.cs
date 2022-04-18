using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Movement : Damagable
    {
        Vector2 moveDir, moveSpeed = new Vector2(1, 0.75f);
        protected float deltaX, deltaY;
        RaycastHit2D hitObject;
        BoxCollider2D boxCol;

        Vector2 deltaDir;


        protected virtual void Start()
        {
            boxCol = GetComponent<BoxCollider2D>();
        }

        protected virtual void Update()
        {
            FaceDirection();
            CheckCollision();
            DeltaPosition();
        }

        

        protected void MovementInput(Vector3 moveInput)
        {
            deltaDir = new Vector2(moveInput.x, moveInput.y);
        }

        void FaceDirection()
        {
            if (deltaDir.x > 0)
                transform.localScale = Vector3.one;
            else if (deltaDir.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }

        void CheckCollision()
        {
            hitObject = Physics2D.BoxCast(transform.position, boxCol.size, 0, new Vector2(0, deltaDir.y), Mathf.Abs(deltaDir.y * Time.deltaTime));
            if (hitObject.collider)
            {
                deltaDir.y = 0;
            }

            hitObject = Physics2D.BoxCast(transform.position, boxCol.size, 0, new Vector2(deltaDir.x, 0), Mathf.Abs(deltaDir.x * Time.deltaTime));
            if (hitObject.collider)
            {
                deltaDir.x = 0;
            }
        }
        void DeltaPosition()
        {
            moveDir = deltaDir * moveSpeed * Time.deltaTime;

            transform.Translate(moveDir);
        }
    }

}

