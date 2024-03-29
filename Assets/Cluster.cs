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
        
        if(snapPixels.Count < transform.childCount) return null;
        return GetCenterOfGameObjects(snapPixels) + Vector3.up;
    }

    public Vector3? GetCenterOfGameObjects(Transform parent)
    {
        Vector3 centerPos = Vector3.zero;
        foreach (Transform item in parent)
            centerPos += item.position;

        if (parent.childCount == 0) return null;

        centerPos /= parent.childCount;
        return centerPos;
    }

    public Vector3? GetCenterOfGameObjects(List<Transform> Objs)
    {
        Vector3 centerPos = Vector3.zero;
        foreach (Transform item in Objs)
            centerPos += item.position;

        if (Objs.Count == 0) return null;

        centerPos /= Objs.Count;
        return centerPos;
    }

    public void RecenterCluster()
    {
        if (transform.childCount == 0) return;

        Vector3 centerOfCluster = GetCenterOfGameObjects(transform) ?? Vector3.zero;

        foreach (Transform item in transform)
        {
            Vector3 diff = item.localPosition - centerOfCluster;
            item.localPosition = transform.position + diff;
        }
    }
}