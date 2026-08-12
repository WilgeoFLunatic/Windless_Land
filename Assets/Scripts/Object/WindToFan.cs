using System.Collections.Generic;
using UnityEngine;

public class WindToFan : MonoBehaviour, IWindReceiver
{
    public List<GameObject> changeStateObj = new();
    public float duration;
    public bool isKeepState = false;
    public bool isPowerEffectDuration = false;
    public float powerEffectDurationBouns = 1f;
    public float rotateSpeedBouns = 500f;
    public float currentPower;
    public float rotateDrag = 0.99f;

    private float timer;
    private float targetSpeed;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer <= duration)
        {
            transform.Rotate(Vector3.forward, targetSpeed * Time.deltaTime);
        }
        else if (timer > duration)
        {
            targetSpeed *= rotateDrag;
            transform.Rotate(Vector3.forward, targetSpeed * Time.deltaTime);
            currentPower = 0;
        }

    }

    public void ReceiveWind(Vector2 direction, float power)
    {
        //implement function
        //Debug.Log("ReceiveWind");
        SetState(changeStateObj, true, duration);
        SpinFan(power);
    }
    public void SetState(List<GameObject> objs, bool state, float duration)
    {
        //Debug.Log("WindToFan");
        foreach (GameObject obj in objs)
        {
            obj.GetComponent<BinaryStateObj>().Set(state, duration, isKeepState);
        }
    }

    public void SpinFan(float power)
    {
        if (currentPower < power)
        {
            currentPower = power;
            targetSpeed = currentPower * rotateSpeedBouns;
            timer = 0;
        }
        if (isPowerEffectDuration)
        {
            duration = power * powerEffectDurationBouns;
        }

    }



}
