using UnityEngine;

public class WindToChest : MonoBehaviour, IWindBlocker, IWindReceiver
{
    public float powerBouns = 13;
    private Rigidbody2D rb;
    [SerializeField] private float windResistance = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void ReceiveWind(Vector2 direction, float power)
    {
        Debug.Log("WindToChest");
        float realPower = power / windResistance;
        Debug.Log("power:" + power + " realPower:" + realPower);
        rb.AddForce(direction * realPower * powerBouns, ForceMode2D.Impulse);
    }
}
