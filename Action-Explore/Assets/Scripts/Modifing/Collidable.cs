using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForcePage
{
    public class Collidable : MonoBehaviour
    {
        [SerializeField] ContactFilter2D filter;
        BoxCollider2D boxCol;
        Collider2D[] hits = new Collider2D[10];
        protected PlayerBehaviour _player;

        protected virtual void Start()
        {
            boxCol = GetComponent<BoxCollider2D>();
            _player = GetComponent<PlayerBehaviour>();
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

}

