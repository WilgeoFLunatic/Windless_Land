using UnityEngine;
using UnityEngine.UI;

public class SummonPlayer : MonoBehaviour
{
    public GameObject player;
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Summon);
    }

    public void Summon()
    {
        Instantiate(player);
    }
}
