using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class Manager : MonoBehaviour
    {
        public static Manager instance;

        

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
