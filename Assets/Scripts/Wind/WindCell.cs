using UnityEngine;

public class WindCell : MonoBehaviour
{
    public Sprite windSprite;
    public Vector2 direction;
    public float power;
    public float duration = 0.5f;
    public bool isBlock = false;
    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = windSprite;
    }
    void Start()
    {
        Destroy(gameObject, duration);
    }
    public void SetWind(Vector2 dir, float strength)
    {
        direction = dir.normalized;
        power = strength;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isBlock = true;

        var receiver = other.GetComponent<IWindReceiver>();

        if (receiver != null)
        {

            receiver.ReceiveWind(
            direction,
            power
            );

        }

    }



}
