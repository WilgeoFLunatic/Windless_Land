using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class PlayAudioEventSO : ScriptableObject
{
    public UnityAction<AudioClip> OnEventRasied;
    public void RaiseEvent(AudioClip audioClip)
    {
        OnEventRasied?.Invoke(audioClip);
    }
}
