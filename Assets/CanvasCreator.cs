using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCreator : MonoBehaviour
{
    public int size = 100;
    public float pixelGap = 0.1f;
    public Vector3 pixelSize;
    public GameObject pixel;

    public Texture2D image;

    // Start is called before the first frame update
    void Awake()
    {
        //CreateCanvas(size, pixel, pixelGap);
        CreateCanvasWithImage(image, pixel, pixelGap);
    }

    void CreateCanvas(int size, GameObject pixel, float pixelGap)
    {
        DeleteCanvas();
        Vector3 placePos = new Vector3(0, 0, 0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject createdPixel = Instantiate(pixel, placePos, Quaternion.identity, this.transform);
                createdPixel.transform.localScale = pixelSize;
                placePos.z += pixelSize.z + pixelGap;
            }
            placePos.z = 0;
            placePos.x += pixelSize.x + pixelGap;
        }
    }
    void CreateCanvasWithImage(Texture2D image, GameObject pixel, float pixelGap)
    {
        DeleteCanvas();
        Vector3 placePos = new Vector3(0, 0, 0);

        for (int i = 0; i < image.width; i++)
        {
            for (int j = 0; j < image.height; j++)
            {
                GameObject createdPixel = Instantiate(pixel, this.transform);
                createdPixel.transform.localPosition = placePos;
                createdPixel.transform.localScale = pixelSize;
                placePos.z += pixelSize.z + pixelGap;
                createdPixel.GetComponent<Pixel>().color = image.GetPixel(i, j);
                Debug.Log(image.GetPixel(i, j));
            }
            placePos.z = 0;
            placePos.x += pixelSize.x + pixelGap;
        }
    }

    void DeleteCanvas()
    {
        foreach (Transform item in transform.GetComponentsInChildren<Transform>())
        {
            if (item != transform)
            {
                DestroyImmediate(item.gameObject);
            }
        }
    }
}