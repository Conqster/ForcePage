using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class MouseInput : MonoBehaviour
    {
        [SerializeField] MoveController bombTestControl;
        ClickableTiles currentTile;

        Vector3 moveTarget;

        void Update()
        {
            DoRayCast();
        }

        void DoRayCast()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (hit.collider != null)
            {

                currentTile = hit.transform.GetComponent<ClickableTiles>();


                if (currentTile != null)
                {

                    if (Input.GetMouseButtonDown(0))
                    {
                        MovePlayer();
                    }
                }
            }
        }

        void MovePlayer()
        {
            moveTarget = currentTile.transform.position;
            bombTestControl.MoveToTarget(moveTarget);
        }

    }
}

