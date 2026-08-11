using Unity.Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private CinemachineConfiner2D confiner2D;
    private void Awake()
    {
        confiner2D = GetComponent<CinemachineConfiner2D>();
    }
    void Start()
    {
        GetNewCameraBounds();
    }

    private void GetNewCameraBounds()
    {
        var obj = GameObject.FindGameObjectWithTag("Bounds");
        if (obj == null)
        {
            return;
        }
        confiner2D.BoundingShape2D = obj.GetComponent<Collider2D>();
    }
}
