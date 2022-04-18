using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    [SerializeField] ContactFilter2D filter;
    BoxCollider2D boxCol;
    Collider2D[] hits = new Collider2D[5];

    protected virtual void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        boxCol.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                break;

            OnCollide(hits[i]);

            hits[i] = null;
        }
    }


    
    protected virtual void OnCollide(Collider2D collision)
    {
        //Debug.Log("OnCollide was not implemented in " + this.name);
    }
}
