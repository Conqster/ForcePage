using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : Damagable
{
    BoxCollider2D boxCol;
    Vector3 changeInPosition;
    RaycastHit2D hitObject;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

    protected virtual void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {

        //changeInPosition = input;
        changeInPosition = new Vector3(input.x * xSpeed, input.y * ySpeed);

        //Switch sprite lef or right 
        if (changeInPosition.x > 0)
            transform.localScale = Vector3.one;
        else if (changeInPosition.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);


        //add pudh vector if any

        changeInPosition += pushDirection;
        //reduce push force every frame, based off recovery speed 
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //to check if the box cast hits anyting 
        //if it does we canyt go there( we have either hit something on the character or wall layer)
        // and we dont want to over lap 
        // for the y direction
        hitObject = Physics2D.BoxCast(transform.position, boxCol.size, 0, new Vector2(0, changeInPosition.y), Mathf.Abs(changeInPosition.y * Time.deltaTime), LayerMask.GetMask("Character", "Wall"));
        // to move the player
        if (hitObject.collider == null)
        {
            transform.Translate(0, changeInPosition.y * Time.deltaTime, 0);
        }

        // for the x direction
        hitObject = Physics2D.BoxCast(transform.position, boxCol.size, 0, new Vector2(changeInPosition.x, 0), Mathf.Abs(changeInPosition.x * Time.deltaTime), LayerMask.GetMask("Character", "Wall"));
        // to move the player
        if (hitObject.collider == null)
        {
            transform.Translate(changeInPosition.x * Time.deltaTime, 0, 0);
        }
    }
}
