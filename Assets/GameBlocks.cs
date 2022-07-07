using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameBlocks : MonoBehaviour
{
    public List<GameBlock> blocks = new();
    public Transform clustersParent;

    public void CreateClusters()
    {
        List<List<GameBlock>> clusters = new();
        int clusterNumber = 1;
        while (transform.childCount>0)
        {
            List<GameBlock> cluster = GetMostPopular().neighbors;
            GameObject clusterObject = new GameObject(clusterNumber.ToString());
            clusterObject.AddComponent<Cluster>();

            clusterObject.transform.SetParent(clustersParent);
            foreach (GameBlock gb in cluster)
            {
                gb.transform.SetParent(clusterObject.transform);
            }
            clusterNumber++;
        }

    }

    public GameBlock GetMostPopular()
    {
        GameBlock mostPopular = transform.GetChild(0).GetComponent<GameBlock>();
        foreach(GameBlock item in transform.GetComponentsInChildren<GameBlock>())
        {
            item.FindNeighbors();
            if (mostPopular.neighbors.Count < item.neighbors.Count) mostPopular = item;
        }
        return mostPopular;
    }

    public void StartSeperation()
    {
        CreateClusters();
    }
}
