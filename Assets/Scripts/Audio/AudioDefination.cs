using System;
using UnityEngine;
using UnityEngine.Events;

public class AudioDefination : MonoBehaviour
{
    public PlayAudioEventSO _playAudioEvent;
    public AudioClip _audioClip;
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
        _playAudioEvent.RaiseEvent(_audioClip);
    }
}
