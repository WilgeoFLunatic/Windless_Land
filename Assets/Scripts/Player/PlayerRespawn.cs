using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerRespawn : MonoBehaviour
{
    public string targetSceneName;
    private PlayerInput _playerInput;
    private InputAction _playerRespawn;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerRespawn = _playerInput.actions["Respawn"];
    }
    // Update is called once per frame
    void Update()
    {
        if (_playerRespawn.triggered)
        {
            LoadTargetScene();
        }
    }


    public void LoadTargetScene()
    {
        if (string.IsNullOrWhiteSpace(targetSceneName))
        {
            Debug.LogWarning("ScenesManager needs a target scene name.");
            return;
        }

        SceneManager.LoadScene(targetSceneName);
    }
}
