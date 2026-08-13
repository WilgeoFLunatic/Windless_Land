using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonSth : MonoBehaviour
{
    public List<GameObject> listObj = new();
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Summon);
    }

    public void Summon()
    {
        foreach (var obj in listObj)
            Instantiate(obj);
    }
}
