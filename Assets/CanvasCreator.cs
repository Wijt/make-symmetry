using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCreator : MonoBehaviour
{
    public int size = 100;
    public float pixelGap = 0.1f;
    public Vector3 pixelSize;
    public GameObject pixel;
    public GameObject gameBlock;

    public GameBlocks gameBlocks;

    public Texture2D image;


    // Start is called before the first frame update
    void Awake()
    {
        //CreateCanvas(size, pixel, pixelGap);
        CreateCanvasWithImage(image, pixel, gameBlock, pixelGap);
        gameBlocks.StartSeperation();
    }

    void CreateCanvasWithImage(Texture2D image, GameObject pixel, GameObject gameBlock, float pixelGap)
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
                Color pColor = image.GetPixel(i, j);
                createdPixel.GetComponent<Pixel>().color = pColor;

                if (pColor == new Color(1, 1, 1, 0))
                {
                    placePos.z += pixelSize.z + pixelGap;
                    continue;
                }

                if (i >= image.width / 2)
                { //on the right side of the canvas
                    GameObject createdPixelExample = Instantiate(gameBlock, gameBlocks.transform);
                    createdPixelExample.transform.localPosition = new Vector3(placePos.x, placePos.y, placePos.z);
                    createdPixelExample.GetComponent<GameBlock>().color = pColor;
                    createdPixelExample.GetComponent<GameBlock>().materialColor = pColor;
                    createdPixel.AddComponent<PixelControl>();
                }
                else
                { //on the left side of the canvas
                    GameObject createdPixelExample = Instantiate(gameBlock, this.transform);
                    createdPixelExample.transform.localPosition = new Vector3(placePos.x, placePos.y + pixelSize.y, placePos.z);
                    createdPixelExample.GetComponent<GameBlock>().color = pColor;
                    createdPixelExample.GetComponent<GameBlock>().materialColor = pColor;
                }
                placePos.z += pixelSize.z + pixelGap;
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