using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool inappropriate;
    public Color greenColor, redColor;

    SpriteRenderer sRend;

    private void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (inappropriate == true)
        {
            sRend.color = redColor;
        }
        else
        {
            sRend.color = greenColor;
        }
    }

}
