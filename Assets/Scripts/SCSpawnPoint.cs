using UnityEngine;
using UnityEngine.UI;

public class SCSpawnPoint : MonoBehaviour
{
    public GameObject player;

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnCallBack);
    }

    void OnCallBack()
    {
        GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().SetSpawnPoint(player.transform.position);
    }
}
