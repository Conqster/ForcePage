using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class TestingCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            print("Something!!!!!!!");
            Destroy(gameObject);
        }
    }

}
