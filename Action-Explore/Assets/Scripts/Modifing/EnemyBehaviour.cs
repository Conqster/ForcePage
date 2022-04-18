using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class EnemyBehaviour : Movement
    {
        [SerializeField] float chaseRange = 1;
        [SerializeField] float chaseLenght = 5;

        bool chasing, collidingWithPlayer;
        Transform _playerTransform;
        Vector3 startingPosition;

        //Hitbox
        ContactFilter2D filter;
        BoxCollider2D hitbox;
        Collider2D[] hits = new Collider2D[5];


        protected override void Start()
        {
            base.Start();
            _playerTransform = GameObject.Find("Player").transform;
            startingPosition = transform.position;
            hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        }


        protected override void Update()
        {
            EnemyMovement();
            base.Update();
        }
        void EnemyMovement()
        {
            if(Vector2.Distance(_playerTransform.position, startingPosition)< chaseLenght)
            {
                if(Vector2.Distance(_playerTransform.position, startingPosition) < chaseRange)
                {
                    chasing = true;
                }

                if(chasing)
                {
                    if(!collidingWithPlayer)
                    {
                        MovementInput((_playerTransform.position - transform.position).normalized);
                    }
                }
                else
                {
                    MovementInput(startingPosition - transform.position);
                }
            }
            else
            {
                MovementInput(startingPosition - transform.position);
                chasing = false;
            }

            //check for overlaps
            collidingWithPlayer = false;
            hitbox.OverlapCollider(filter, hits);
            for(int i = 0; i < hits.Length; i++)
            {
                if (hits[i] == null)
                    break;

                if(hits[i].tag == "Player" && hits[i].name == "Player")
                {
                    collidingWithPlayer = true;
                }
                hits[i] = null;
            }
        }

        protected override void Death()
        {
            Destroy(gameObject);
        }
    }

}
