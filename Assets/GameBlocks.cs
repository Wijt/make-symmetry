using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameBlocks : MonoBehaviour
{
    List<List<GameBlock>> clusters = new();
    List<List<GameBlock>> randomizedClusters = new();
    public Transform clustersParent;

    [Range(0f, 1f)]
    public float randomizeRate = 0.53f;
    
    [Range(0f, 1f)]
    public float randomizeChange = 0.4f;
    public void CreateClusters()
    {
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

    public void RandomizeClusters()
    {
        int totalRandom =  Mathf.CeilToInt(clusters.Count * randomizeRate);

        while (totalRandom > 0)
        {
            foreach (List<GameBlock> cl in clusters)
            {
                foreach (GameBlock gameBlock in cl)
                {
                    foreach (GameBlock neighbor in gameBlock.neighbors)
                    {
                        if (neighbor.transform.parent == gameBlock.transform.parent) continue;

                        if (Random.Range(0f, 1f) < randomizeChange) continue;

                        gameBlock.transform.SetParent(neighbor.transform.parent);
                        totalRandom -= 1;

                        gameBlock.transform.parent.GetComponent<Cluster>().RecenterCluster();
                        neighbor.transform.parent.GetComponent<Cluster>().RecenterCluster();

                        break;
                    }
                }
            }
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
        RandomizeClusters();
    }
}
