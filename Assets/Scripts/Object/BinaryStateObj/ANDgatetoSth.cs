using System.Collections.Generic;
using UnityEngine;

public class ANDgatetoSth : MonoBehaviour, IBinaryState
{
    public List<GameObject> Objects;

    public int activateNeed = 2;
    public int activateCount = 0;

    public void Activate()
    {
        activateCount++;

        CheckCount();
    }


    public void Deactivate()
    {
        activateCount--;

        if (activateCount < 0)
            activateCount = 0;
    }


    public void CheckCount()
    {
        if (activateCount >= activateNeed)
        {
            AllActivate();
        }
    }


    private void AllActivate()
    {
        // 这里写全部满足后的逻辑

    }
}