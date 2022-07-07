using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelControl : MonoBehaviour
{
    public bool isOkey = false;

    public bool hasSomething = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GameBlock>() == null) return;

        hasSomething = true;

        Pixel pixel = gameObject.GetComponent<Pixel>();
        GameBlock block = other.gameObject.GetComponent<GameBlock>();

        if (block.color != pixel.color) return;

        isOkey = true;
        FindObjectOfType<GameManager>().Finish();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<GameBlock>() == null) return;

        hasSomething = false;
        isOkey = false;
        FindObjectOfType<GameManager>().Finish();
    }
}
