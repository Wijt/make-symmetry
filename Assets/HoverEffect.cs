using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public Color startColor;
    public Color hoverColor;

    public bool safeToLand = false;

    private Material material;
    private Pixel px;
    
    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        px = GetComponent<Pixel>();
        startColor = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        material.color = startColor;
        safeToLand = false;

        if (px.hasSomething) return;

        RaycastHit hit = CastRay(transform);
        if (hit.collider == null) return;
        if (hit.collider.GetComponent<GameBlock>() == null) return;

        safeToLand = true;
        material.color = hoverColor;
    }

    private RaycastHit CastRay(Transform startObject)
    {
        RaycastHit hit;
        Physics.Raycast(startObject.position, Vector3.up * 4, out hit);
        return hit;
    }
}
