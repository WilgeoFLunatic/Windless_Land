using UnityEngine;

public class AudioDefination : MonoBehaviour
{
    public PlayAudioEventSO _playAudioEvent;

    public AudioClip[] _audioClips; // Inspector拖入多个音效

    public bool playOnEnable;

    private void OnEnable()
    {
        if (playOnEnable)
        {
            PlayAudioClip();
        }
    }

    public void PlayAudioClip()
    {
        if (_audioClips == null || _audioClips.Length == 0)
        {
            Debug.LogWarning("没有设置AudioClip");
            return;
        }

        // 随机选择一个音效
        AudioClip clip = _audioClips[Random.Range(0, _audioClips.Length)];

        _playAudioEvent.RaiseEvent(clip);
    }
}