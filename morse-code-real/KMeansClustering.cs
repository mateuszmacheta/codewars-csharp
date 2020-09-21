using System.Linq;
using System.Collections.Generic;
using System;

public class KMeansClustering
{
    public List<int> Data { get; }
    public int ClusterNumber { get; }
    private int maxIterations { get; }
    public List<List<int>> ClusterData { get; }
    public double[] clusterMeans { get; }

    public KMeansClustering(int clusterNumber, List<int> data)
    {
        maxIterations = 100;
        ClusterNumber = clusterNumber;
        ClusterData = new List<List<int>>();

        for (int i = 0; i < clusterNumber; i++)
        {
            ClusterData.Add(new List<int>());
        }

        Data = data;

        SimpleInit();

        clusterMeans = new double[ClusterNumber];
    }

    private void UpdateMeans()
    {
        for (int i = 0; i < ClusterNumber; i++)
        {
            clusterMeans[i] = ClusterData[i].Average();
        }
    }
    private void SimpleInit()
    {
        var rnd = new Random();
        for (int i = 0; i < Data.Count; i++)
        {
            ClusterData[rnd.Next() % ClusterNumber].Add(Data[i]);
        }
    }

    public bool FindClusters()
    {
        for (int i = 0; i < maxIterations; i++)
        {
            bool changed = false;
            UpdateMeans();
            double[] distances = new double[ClusterNumber];
            List<List<int>> newClusterData = new List<List<int>>();

            for (int j = 0; j < ClusterNumber; j++)
            {
                newClusterData.Add(new List<int>());
            }

            // reassign datapoints to clusters based on lowest distance to cluster ceters

            for (int j = 0; j < ClusterNumber; j++)
            {
                foreach (var datapoint in ClusterData[j])
                {
                    for (int k = 0; k < ClusterNumber; k++)
                    {
                        distances[k] = Math.Abs(datapoint - clusterMeans[k]);
                    }
                    int newClusterIndex = Array.IndexOf(distances, distances.Min());
                    newClusterData[newClusterIndex].Add(datapoint);
                }
            }

            // check if cluster members changed - costly but convenient
            for (int j = 0; j < ClusterNumber; j++)
            {
                changed = !Enumerable.SequenceEqual(ClusterData[j].OrderBy(i => i), newClusterData[j].OrderBy(i => i));
                if (changed) { break; }
            }

            // if no changes then we finish
            if (!changed)
            { return true; }

            ClusterData.Clear();
            ClusterData.AddRange(newClusterData);
        }
        return false;
    }

}