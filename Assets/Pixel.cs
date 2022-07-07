using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    public Color color;
    public bool hasSomething = false;

    public Color materialColor
    {
        get => GetComponent<Renderer>().material.color;
        set => GetComponent<Renderer>().material.color = value;
    }


    private void OnTriggerEnter(Collider other)
    {
        hasSomething = true;
    }

    private void OnTriggerExit(Collider other)
    {
        hasSomething = false;
    }
}