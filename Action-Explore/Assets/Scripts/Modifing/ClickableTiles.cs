using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    public class ClickableTiles : MonoBehaviour
    {
        Color normalColour = new Color(1, 1, 1);
        Color clickedColour = new Color(0.7f, 0f, 0.7f);


        public void SetTileColour()
        {
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            mySprite.color = clickedColour;
            Invoke("ResetTileColour", 4.5f);
        }

        private void ResetTileColour()
        {
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            mySprite.color = normalColour;
        }
    }
}
