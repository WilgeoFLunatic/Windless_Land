using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [Header("视差强度")]
    [Range(0f, 1f)]
    public float parallaxStrength = 0.5f;

    private Transform cam;

    private Vector3 lastCamPosition;


    void Start()
    {
        cam = Camera.main.transform;

        lastCamPosition = cam.position;
    }


    void LateUpdate()
    {
        Vector3 camDelta = cam.position - lastCamPosition;

        // 只让背景X轴产生视差
        transform.position += new Vector3(
            camDelta.x * parallaxStrength,
            0,
            0
        );

        lastCamPosition = cam.position;
    }
}