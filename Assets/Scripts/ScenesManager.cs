using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private string targetSceneName = "SecScene";

    [Header("Optional Inspector Links")]
    [SerializeField] private InputField sceneNameInput;
    [SerializeField] private Button switchButton;

    [Header("Optional Keyboard Shortcut")]
    [SerializeField] private bool allowKeyboardSwitch;
    [SerializeField] private KeyCode switchKey = KeyCode.Return;

    private void Awake()
    {
        if (sceneNameInput != null)
        {
            sceneNameInput.text = targetSceneName;
            sceneNameInput.onValueChanged.AddListener(SetTargetScene);
        }

        if (switchButton != null)
        {
            switchButton.onClick.AddListener(LoadTargetScene);
        }
    }

    private void Update()
    {
        if (allowKeyboardSwitch && Input.GetKeyDown(switchKey))
        {
            LoadTargetScene();
        }
    }

    private void OnDestroy()
    {
        if (sceneNameInput != null)
        {
            sceneNameInput.onValueChanged.RemoveListener(SetTargetScene);
        }

        if (switchButton != null)
        {
            switchButton.onClick.RemoveListener(LoadTargetScene);
        }
    }

    public void SetTargetScene(string sceneName)
    {
        targetSceneName = (sceneName ?? string.Empty).Trim();
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

    public void LoadScene(string sceneName)
    {
        SetTargetScene(sceneName);
        LoadTargetScene();
    }
}
