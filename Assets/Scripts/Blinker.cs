using System.Collections;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    //to plug in the sprite
    public SpriteRenderer spriteRenderer;

    //storing color swatches
    public Color lit = Color.lightGreen;
    public Color dark = Color.forestGreen;

    //speed at which stuff happens
    public float blinkSPD = 1f;

    //toggles the color
    public bool Lit = false;

    //forces the coroutine to loop
    public bool On = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //turns on the blinker
        StartCoroutine(Blinking());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Blinking()
    {
        while (On)
        {

            //if on turns it off
            if (Lit)
            {
                spriteRenderer.color = dark;
                Lit = false;
                yield return new WaitForSeconds(blinkSPD);
            }

            //if off turns it on
            if (!Lit)
            {
                spriteRenderer.color = lit;
                Lit = true;
                yield return new WaitForSeconds(blinkSPD);
            }

            
        }

    }
}

