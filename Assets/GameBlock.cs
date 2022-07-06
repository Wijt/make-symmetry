using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBlock : MonoBehaviour
{
    public Color color;

    public Color materialColor
    {
        get => GetComponent<Renderer>().material.color;
        set => GetComponent<Renderer>().material.color = value;
    }

    public List<GameBlock> neighbors = new();

    public List<GameBlock> GetNeighboursOfSameColor()
    {
        List<GameBlock> sameColorBlocks = new();
        foreach (Transform gb in transform.parent)
        {
            GameBlock gbb = gb.GetComponent<GameBlock>();
            if (gbb.color == color)
            {
                sameColorBlocks.Add(gb.GetComponent<GameBlock>());
            }
        }
        List<GameBlock> neighbours = new();
        foreach (GameBlock gb in sameColorBlocks)
        {
            float dist = Vector3.Distance(this.transform.position, gb.transform.position);
            if (dist < 1.25f) neighbours.Add(gb);
        }
        return neighbours;
    }
    
    public void FindNeighbors()
    {
        neighbors = GetNeighboursOfSameColor();
    }
}