using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Damagable : MonoBehaviour
    {
        [SerializeField] int health;

        [SerializeField] float hitColourTime = 0.75f;
        SpriteRenderer sp;


        


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
