using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Manager : MonoBehaviour
    {
        public static Manager instance;

        //[Range(0f, 100f)]
        //[SerializeField] float health = 90;

        //public float hp
        //{
        //    get
        //    {
        //        return health;
        //    }
        //    set
        //    {
        //        health += value;
        //    }
        //}

        //public void UpdateHealth(float valueToAdd)
        //{
        //    health += valueToAdd;
        //}

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


    }

}
