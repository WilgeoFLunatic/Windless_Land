using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Vector3 PlayerSpawnPoint { get; private set; }

    void Awake()
    {
        SetSpawnPoint(new Vector3(-6, -2, 0));
        DontDestroyOnLoad(gameObject);
    }

    public void SetSpawnPoint(Vector3 pos)
    {
        PlayerSpawnPoint = pos;
    }
}
