using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform lookAt;
    [SerializeField] float frameX = 0.15f, frameY = 0.05f;


    void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // this is to check if we are inside the bound on the x Axis
        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > frameX || deltaX < -frameX)
        {
            if(transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - frameX;
            }
            else
            {
                delta.x = deltaX + frameX;
            }
        }


        // this is to check if we are inside the bound on the y Axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > frameY || deltaY < -frameY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - frameY;
            }
            else
            {
                delta.y = deltaY + frameY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
