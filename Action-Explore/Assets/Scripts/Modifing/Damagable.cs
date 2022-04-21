using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Damagable : MonoBehaviour
    {

        [SerializeField] protected float hitColourTime = 0.75f;
        SpriteRenderer sp;

        [SerializeField] protected float health;

        

        protected virtual void RecieveDamage(DealDamage dmg)
        {
            health -= dmg.damage;
            //print(health);
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
            Destroy(gameObject);
        }

        
    }

}
