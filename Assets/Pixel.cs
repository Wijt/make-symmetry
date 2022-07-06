using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    public Color color
    {
        get => GetComponent<Renderer>().material.color;
        set => GetComponent<Renderer>().material.color = value;
    }

    void Start()
    {
        //colorManager = GameObject.Find("ColorChanger").GetComponent<ColorChangeManager>();
        //color = colorManager.GetRandomColor();
    }
}