using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Collidable
{
    protected bool collected;

    protected override void OnCollide(Collider2D col)
    {
        if(col.name == "Player")
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        collected = true;
    }
}
