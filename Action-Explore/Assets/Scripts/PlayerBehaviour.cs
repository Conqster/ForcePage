using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    BoxCollider2D boxCol;
    Vector3 changeInPosition;
    RaycastHit2D hitObject;

    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        changeInPosition = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        changeInPosition = new Vector3(x, y);

        //Switch sprite lef or right 
        if (changeInPosition.x > 0)
            transform.localScale = Vector3.one;
        else if (changeInPosition.x < 0)
            transform.localScale = new Vector3(-1,1,1);

        //to check if the box cast hits anyting 
        //if it does we canyt go there( we have either hit something on the character or wall layer)
        // and we dont want to over lap 
        // for the y direction
        hitObject = Physics2D.BoxCast(transform.position, boxCol.size, 0, new Vector2(0, changeInPosition.y), Mathf.Abs(changeInPosition.y * Time.deltaTime), LayerMask.GetMask("Character", "Wall"));
        // to move the player
        if(hitObject.collider == null)
        {
            transform.Translate(0, changeInPosition.y * Time.deltaTime,0);
        }

        // for the x direction
        hitObject = Physics2D.BoxCast(transform.position, boxCol.size, 0, new Vector2(changeInPosition.x,0), Mathf.Abs(changeInPosition.x * Time.deltaTime), LayerMask.GetMask("Character", "Wall"));
        // to move the player
        if (hitObject.collider == null)
        {
            transform.Translate(changeInPosition.x * Time.deltaTime, 0,0);
        }
    }
}
