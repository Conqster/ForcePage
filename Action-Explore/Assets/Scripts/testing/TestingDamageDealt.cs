using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ForcePage;



public class TestingDamageDealt : MonoBehaviour
{

    PlayerBehaviour _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            DealDamage dmg = new DealDamage();
            dmg.damage = 10;

            _player.SendMessage("RecieveDamage", dmg);
        }
    }
}
