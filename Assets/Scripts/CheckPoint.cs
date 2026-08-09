using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform cameraPos;
    public Vector3 spawnPoint;
    void Awake()
    {
        spawnPoint = transform.position;
    }
}
