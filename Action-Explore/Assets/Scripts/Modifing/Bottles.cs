using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Bottles : Damagable
    {
        protected override void Death()
        {
            Destroy(gameObject);
        }
    }

}
