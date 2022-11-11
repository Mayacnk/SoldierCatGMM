using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MayaGame
{
    public class GridController : MonoBehaviour
    {
        [SerializeField] GameObject GridP;
        [SerializeField] float x, yy;
        int a=0;

        private void Start()
        {
            for (int i = -6; i < x; i++)
            {
                for (int y = -4; y < yy; y++)
                {
                    GameObject grid = Instantiate(GridP, transform) as GameObject;
                    grid.transform.position = new Vector3(i, y, 0f);
                    GameController.Instance.tiles[a] = grid.GetComponent<Tile>();
                        a++;
                }
            }
        }
    }
}