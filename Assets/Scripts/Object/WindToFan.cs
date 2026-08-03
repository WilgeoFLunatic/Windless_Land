using System.Collections.Generic;
using UnityEngine;

public class WindToFan : MonoBehaviour, IWindReceiver
{
    public List<GameObject> changeStateObj = new();
    public float duration;
    public float rotateSpeedBouns = 500f;
    public float currentPower;
    public float rotateDrag = 0.9f;

    private float targetSpeed;
    private void Update()
    {
        targetSpeed *= rotateDrag;

        transform.Rotate(
            Vector3.forward,
            targetSpeed * Time.deltaTime
        );
        if (targetSpeed < 1000)
        {
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
            obj.GetComponent<BinaryStateObj>().Set(state, duration);
        }
    }

    public void SpinFan(float power)
    {
        if (currentPower < power)
        {
            currentPower = power;
            targetSpeed = currentPower * rotateSpeedBouns;
        }

    }



}
