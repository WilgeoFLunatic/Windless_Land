using UnityEngine;

public class BinaryStateObj : MonoBehaviour
{
    public bool isActivated = false;
    public float durationObj;
    public bool isKeepState = true;
    private IBinaryState stateObj;
    private float timer;
    void Awake()
    {
        stateObj = GetComponent<IBinaryState>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (isKeepState)
        {
            return;
        }
        if (!isActivated)
        {
            return;
        }
        if (timer >= durationObj)
        {
            Deactivate();
        }
    }
    public void Activate()
    {
        stateObj?.Activate();
    }

    public void Deactivate()
    {
        stateObj?.Deactivate();
    }

    public void Set(bool state, float duration)
    {
        if (!isActivated && state)
        {
            //Debug.Log("Set");
            isActivated = true;
            durationObj = duration;
            Activate();
            timer = 0;
        }
        else if (isActivated && state)
        {
            durationObj = duration;
            timer = 0;
        }
        else if (isActivated && !state)
        {
            isActivated = false;
            Deactivate();
        }
    }
}
