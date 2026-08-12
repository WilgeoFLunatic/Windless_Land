using System.Collections;
using UnityEngine;

public class MoveLinearly : MonoBehaviour, IBinaryState
{
    public Transform startPoint;
    public Transform endPoint;
    public Vector3 startPos;
    public Vector3 endPos;
    public float duration = 1f;

    private Rigidbody2D rb;
    private Coroutine moveCoroutine;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = startPoint.position;
        endPos = endPoint.position;
    }


    private void Start()
    {
        rb.position = startPos;
    }


    public void Activate()
    {
        Debug.Log(gameObject.name + " Activate");

        Vector2 currentPos = rb.position;

        // 判断是否在起点附近
        if (Vector2.Distance(currentPos, startPos) < 0.01f)
        {
            StartMove(startPos, endPos);
        }
        else
        {
            // 从当前位置移动到终点
            StartMove(currentPos, endPos);
        }
    }


    public void Deactivate()
    {
        Debug.Log(gameObject.name + " Deactivate");

        Vector2 currentPos = rb.position;

        if (Vector2.Distance(currentPos, endPos) < 0.01f)
        {
            StartMove(endPos, startPos);
        }
        else
        {
            // 从当前位置返回起点
            StartMove(currentPos, startPos);
        }
    }


    private void StartMove(Vector2 from, Vector2 to)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveCoroutine(from, to));
    }


    private IEnumerator MoveCoroutine(Vector2 from, Vector2 to)
    {
        float distance = Vector2.Distance(from, to);
        float timer = 0f;

        float moveTime = distance / 5f; // 5 = 移动速度

        while (timer < moveTime)
        {
            timer += Time.fixedDeltaTime;

            float t = timer / moveTime;

            rb.MovePosition(Vector2.Lerp(from, to, t));

            yield return new WaitForFixedUpdate();
        }

        rb.MovePosition(to);

        moveCoroutine = null;
    }
}