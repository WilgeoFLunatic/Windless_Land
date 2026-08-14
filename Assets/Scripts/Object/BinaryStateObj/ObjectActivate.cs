using UnityEngine;

public class ObjectActivate : MonoBehaviour
{
    public void Activate()
    {
        Debug.Log(gameObject.name + " Activate");

        gameObject.SetActive(true);
    }


    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
