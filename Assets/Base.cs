using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    private void Update()
    {
        if (transform.childCount == 0)
        {
            GetRandomCluster();
        }
    }

    public void GetRandomCluster()
    {
        Transform clusters = GameObject.Find("Clusters").transform;
        if (clusters.childCount == 0) return;
        int randomClusterID = Random.Range(0, clusters.childCount);
        Transform cluster = clusters.GetChild(randomClusterID);
        cluster.SetParent(transform);
        cluster.localPosition = Vector3.zero;

        cluster.GetComponent<Cluster>().RecenterCluster();

        cluster.localPosition += Vector3.forward * -1;
        cluster.localScale *= 1.5f;
        LeanTween.scale(cluster.gameObject, cluster.localScale * 2f, 0.25f).setEasePunch();
    }

    public Vector3 GetCenterOfGameObjects(Transform parent)
    {
        Vector3 centerPos = Vector3.zero;
        foreach (Transform item in parent)
        {
            centerPos += item.position;
        }
        centerPos /= parent.childCount;
        return centerPos;
    }
}
