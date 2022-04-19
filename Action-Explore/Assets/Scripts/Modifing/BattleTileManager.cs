using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForcePage
{
    public class BattleTileManager : MonoBehaviour
    {
        [SerializeField] GameObject[] battleTiles;
        int battleFieldSize = 6;
        Color colA = new Color(0.7f, 0.2f, 0.3f);
        Color colB = new Color(0.1f, 0.3f, 0.7f);


        Vector3 position;
        private void Start()
        {
            MakeBoard(battleFieldSize);
        }

        void MakeBoard(int boardSize)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    int tileNumber = Random.Range(0, battleTiles.Length);

                    Vector3 managerPos = transform.position;
                    if(i == 0 && j == 0)
                    {
                       position = new Vector3(i, j);
                    }
                    else
                    {
                        position = new Vector2(i, j) / 2;
                    }
                    Vector3 tilePos = transform.position + position;
                    GameObject tile = Instantiate(battleTiles[tileNumber], tilePos, Quaternion.identity);

                    // colour the tile on the even squares to be darker
                    if ((i + j) % 2 == 0)
                    {
                        SpriteRenderer rend = tile.GetComponent<SpriteRenderer>();
                        rend.color = colA;
                    }
                    else if ((i + j) % 2 == 1)
                    {
                        SpriteRenderer rend = tile.GetComponent<SpriteRenderer>();
                        rend.color = colB;
                    }
                }
            }
        }
    }

}
