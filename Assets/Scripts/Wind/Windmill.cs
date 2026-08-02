using UnityEngine;
using UnityEngine.Events;

public class Windmill : MonoBehaviour, IWindReceiver
{
    [SerializeField] private Transform fanBlade;
    [SerializeField] private float speedMultiplier = 500f;
    [SerializeField] private float maxSpeed = 720f;
    [SerializeField] private float damping = 2.5f;
    [SerializeField] private float triggerThreshold = 180f;

    public UnityEvent onActivated;
    public UnityEvent onDeactivated;

    private float currentSpeed = 0f;
    private bool isActivated = false;

    private void Update()
    {
        if (fanBlade != null && Mathf.Abs(currentSpeed) > 0.01f)
        {
            fanBlade.Rotate(0, 0, currentSpeed * Time.deltaTime);
        }

        currentSpeed = Mathf.Lerp(currentSpeed, 0f, damping * Time.deltaTime);
        CheckState();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind") || collision.name.Contains("Wind"))
        {
            ReceiveWind(Vector2.right, 2.0f);
        }
    }

    public void ReceiveWind(Vector2 direction, float power)
    {
        currentSpeed += power * speedMultiplier * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);
    }

    private void CheckState()
    {
        float absSpeed = Mathf.Abs(currentSpeed);

        if (!isActivated && absSpeed >= triggerThreshold)
        {
            isActivated = true;
            onActivated?.Invoke();
        }
        else if (isActivated && absSpeed < (triggerThreshold * 0.5f))
        {
            isActivated = false;
            onDeactivated?.Invoke();
        }
    }
}