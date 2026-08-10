using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform cameraPos;
    public Vector3 spawnPoint;
    public GameObject audioSet;
    void Awake()
    {
        spawnPoint = transform.position;
    }
}
