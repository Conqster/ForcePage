using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : Movement
{
    [SerializeField] int xpValue = 2; // how much xp the enemy worth on death

    //Logics
    [SerializeField] float chaseRange = 1;
    [SerializeField] float chaseLenght = 5;
    bool chasing, collidingWithPlayer;
    Transform playerTransform;
    Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    BoxCollider2D hitbox;
    Collider2D[] hits = new Collider2D[5];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameObject.Find("Player").transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght)
        {
            if(Vector3.Distance(playerTransform.position, startingPosition) < chaseRange)
            {
                chasing = true;
            }

            if(chasing)
            {
                if(!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        //check for overlaps
        collidingWithPlayer = false;
        hitbox.OverlapCollider(filter, hits); //?? hitbox or ....
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                break;

            if(hits[i]. tag == "Player" && hits[i].name == "Player") // might have some errors here .tag == Fighter/Damagable
            {
                collidingWithPlayer = true;
            }
            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameBehaviour.instance.exp += xpValue;
        //need health 
        //need ammo
        // ot maybe drops instance of game for pick ups 
    }

}
