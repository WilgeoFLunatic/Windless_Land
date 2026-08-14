using UnityEngine;

public class WaterDetective : MonoBehaviour
{
    //public float buoyancy = 10f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().PlayerDead();
        }
    }
}
