using System.Collections.Generic;
using UnityEngine;

public class ANDgate : MonoBehaviour, IBinaryState
{
    public List<GameObject> Objects;

    public int activateNeed = 2;
    public int activateCount = 0;
    public void Activate()
    {
        activateCount++;
    }
    public void Deactivate()
    {
        activateCount--;
    }
    public void CheckCount()
    {
        if (activateCount == activateNeed)
        {

        }
    }
}
