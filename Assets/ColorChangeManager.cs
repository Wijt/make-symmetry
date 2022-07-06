using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeManager : MonoBehaviour
{
    public void ChangeColorPixel(GameObject changeObject, Color characterColor)
    {
        changeObject.GetComponent<Pixel>().color = characterColor;
    }
}