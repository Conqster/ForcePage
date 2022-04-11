using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    BoxCollider2D boxCol;

    Vector3 changeInPosition;

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

        // to move the player
        transform.Translate(changeInPosition * Time.deltaTime);

    }
}
