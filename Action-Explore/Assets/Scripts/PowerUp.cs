using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Collectible
{
    //[SerializeField] Sprite emptyChest; // used to swap the chest sprite to an empty one 
    [SerializeField] int powerUp = 1;
    protected override void OnCollide(Collider2D col)
    {
        if(!collected)
        {
            collected = true;
            //GetComponent<SpriteRenderer>().sprite = emptyChest; // logic swaping the sprite for empty chest 
        }
        base.Collect();
        Debug.Log("Grant PowerUp" + powerUp + "!!");
        Destroy(gameObject); // using this because i havent got/ using the chest swap 
    }
}
