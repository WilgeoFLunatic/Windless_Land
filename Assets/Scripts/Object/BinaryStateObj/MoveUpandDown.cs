using UnityEngine;

public class MoveUpandDown : MonoBehaviour, IBinaryState
{
    public Transform startPos;
    public Transform endPos;
    public float duration;
    public void Activate()
    {
        Debug.Log(gameObject.name + " Activate");
    }
    public void Deactivate()
    {
        Debug.Log(gameObject.name + " Deactivate");
    }
}
