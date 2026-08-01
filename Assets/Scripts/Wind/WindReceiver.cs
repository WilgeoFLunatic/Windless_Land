using System;
using UnityEngine;

public class WindReceiver : MonoBehaviour, IWindReceiver
{
    public float powerBouns = 1000f;
    private Rigidbody2D rb;
    [SerializeField] private float windResistance = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void ReceiveWind(Vector2 direction, float power)
    {

        float realPower = power / windResistance;
        //Debug.Log("power:" + power + " realPower:" + realPower);
        rb.AddForce(direction * realPower * powerBouns);
    }

}