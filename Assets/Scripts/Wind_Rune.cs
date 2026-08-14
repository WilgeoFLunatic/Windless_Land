using UnityEngine;

public class Wind_Rune : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            PlaySound();
        }
    }

    void PlaySound()
    {
        GetComponent<AudioDefination>()?.PlayAudioClip();
    }
}
