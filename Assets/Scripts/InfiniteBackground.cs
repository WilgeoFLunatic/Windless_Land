using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    private float width;

    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;

        // 获取当前背景图片宽度
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            width = sr.bounds.size.x;
        }
    }


    private void Update()
    {
        // 摄像机向右移动
        if (cam.position.x - transform.position.x > width)
        {
            MoveRight();
        }

        // 摄像机向左移动
        if (transform.position.x - cam.position.x > width)
        {
            MoveLeft();
        }
    }


    void MoveRight()
    {
        Vector3 pos = transform.position;

        pos.x += width * 3;

        transform.position = pos;
    }


    void MoveLeft()
    {
        Vector3 pos = transform.position;

        pos.x -= width * 3;

        transform.position = pos;
    }
}