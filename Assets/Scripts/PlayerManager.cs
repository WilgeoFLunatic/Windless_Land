using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Vector3 PlayerSpawnPoint { get; private set; }

    void Awake()
    {
        SetSpawnPoint(Vector3.zero);
        DontDestroyOnLoad(gameObject);
    }

    public void SetSpawnPoint(Vector3 pos)
    {
        PlayerSpawnPoint = pos;
    }
}
