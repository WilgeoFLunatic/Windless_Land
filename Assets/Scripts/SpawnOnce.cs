using System.Collections.Generic;
using UnityEngine;

public class SpawnOnce : MonoBehaviour
{
    [Header("需要生成的物体")]
    public List<GameObject> prefabs;

    [Header("生成位置")]
    public Transform spawnPoint;

    private static bool hasSpawned = false;


    void Start()
    {
        if (!hasSpawned)
        {
            SpawnObjects();
            hasSpawned = true;
        }
    }


    void SpawnObjects()
    {
        if (prefabs == null || prefabs.Count == 0)
        {
            Debug.LogWarning("没有设置生成物体");
            return;
        }


        foreach (GameObject prefab in prefabs)
        {
            if (prefab == null)
                continue;


            if (spawnPoint != null)
            {
                Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                Instantiate(prefab);
            }
        }
    }
}