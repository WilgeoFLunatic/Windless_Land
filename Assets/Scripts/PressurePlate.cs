using UnityEngine;
public class PressurePlate : MonoBehaviour
{
    public ANDgate gate;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chest"))
        {
            gate.Activate();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Chest"))
        {
            gate.Deactivate();
        }
    }
}