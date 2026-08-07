using System.Collections;
using UnityEngine;

public class MoveLinearly : MonoBehaviour, IBinaryState
{
    public Transform startPos;
    public Transform endPos;
    public float duration = 1f;

    private Rigidbody2D rb;
    private Coroutine moveCoroutine;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        rb.position = startPos.position;
    }


    public void Activate()
    {
        Debug.Log(gameObject.name + " Activate");

        StartMove(startPos.position, endPos.position);
    }


    public void Deactivate()
    {
        Debug.Log(gameObject.name + " Deactivate");

        StartMove(endPos.position, startPos.position);
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
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.fixedDeltaTime;

            float t = timer / duration;

            Vector2 newPos = Vector2.Lerp(from, to, t);

            rb.MovePosition(newPos);

            yield return new WaitForFixedUpdate();
        }

        //rb.MovePosition(to);

        moveCoroutine = null;
    }
}