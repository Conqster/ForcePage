using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Damagable : MonoBehaviour
    {
        //public int health;
        //[Range(0f, 100f)]
        //[SerializeField] float health;

        [SerializeField] float hitColourTime = 0.75f;
        SpriteRenderer sp;

        //public float hp
        //{
        //    get
        //    {
        //        return health;
        //    }
        //    set
        //    {
        //        health = value;
        //    }
        //}

        [SerializeField] protected float health;

        

        protected virtual void RecieveDamage(DealDamage dmg)
        {
            health -= dmg.damage;

            ReceiveHitColour();
            Invoke("ReceiveHitColour", hitColourTime);

            if(health < 0)
            {
                Death();
            }
        }

        protected void ReceiveHitColour()
        {
            sp = GetComponent<SpriteRenderer>();
            if (sp.color == Color.white)
            {
                sp.color = Color.red;
            }
            else
            {
                sp.color = Color.white;
            }
        }

        protected virtual void Death()
        {
            //print("i'm out!!!!");
        }

        
    }

}
