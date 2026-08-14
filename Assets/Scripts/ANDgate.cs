using System.Collections.Generic;
using UnityEngine;

public class ANDgate : MonoBehaviour
{
    // 需要检测的输入物体
    public List<GameObject> inputObjects;

    // 目标触发对象
    public List<GameObject> targetObjects;

    // 当前激活数量
    public int activateCount = 0;

    // 是否已经触发
    public bool isActivated = false;


    // 输入物体激活时调用
    public void Activate()
    {
        activateCount++;

        CheckGate();
    }


    // 输入物体关闭时调用
    public void Deactivate()
    {
        activateCount--;

        if (activateCount < 0)
            activateCount = 0;

        CheckGate();
    }


    // 检查是否满足条件
    private void CheckGate()
    {
        // 所有物体都激活
        if (activateCount >= inputObjects.Count)
        {
            if (!isActivated)
            {
                isActivated = true;
                Open();
            }
        }
        else
        {
            isActivated = false;
        }
    }


    // 与门触发后的效果
    private void Open()
    {
        Debug.Log("AND Gate Activated!");

        foreach (GameObject obj in targetObjects)
        {
            // 如果目标有接口，就调用
            IBinaryState state = obj.GetComponent<IBinaryState>();

            if (state != null)
            {
                state.Activate();
            }
        }
    }
}