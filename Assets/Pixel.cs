using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    public Color color;

    public Color materialColor
    {
        get => GetComponent<Renderer>().material.color;
        set => GetComponent<Renderer>().material.color = value;
    }
}