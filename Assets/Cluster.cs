using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cluster : MonoBehaviour
{
    public bool canBePlaced
    {
        get { return GetSnapPosition() != null; }
    }

    public Vector3? GetSnapPosition()
    {   
        List<Transform> snapPixels = new();
        foreach (HoverEffect px in FindObjectsOfType<HoverEffect>())
            if (px.safeToLand) snapPixels.Add(px.transform);
        
        if(snapPixels.Count == 0) return null;
        return GetCenterOfGameObjects(snapPixels) + Vector3.up;
    }

    public Vector3? GetCenterOfGameObjects(List<Transform> parent)
    {
        Vector3 centerPos = Vector3.zero;
        foreach (Transform item in parent)
            centerPos += item.position;

        if (parent.Count==0) return null;

        centerPos /= parent.Count;
        return centerPos;
    }
}
