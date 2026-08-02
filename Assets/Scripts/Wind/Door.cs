using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 openOffset = new Vector3(0, 3f, 0);
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 closedPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        closedPosition = transform.position;
        targetPosition = closedPosition;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void Open()
    {
        targetPosition = closedPosition + openOffset;
    }

    public void Close()
    {
        targetPosition = closedPosition;
    }
}