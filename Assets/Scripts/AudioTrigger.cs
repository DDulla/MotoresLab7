using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private RoomAudioSettings roomAudioSettings;

    private void Start()
    {
        audioSource.loop = true; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EnterRoomSequence());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ExitRoomSequence());
        }
    }

    private IEnumerator EnterRoomSequence()
    {
        FadeController.Instance.FadeIn();
        yield return new WaitForSeconds(1f);

        if (roomAudioSettings.RoomMusic != null)
        {
            audioSource.clip = roomAudioSettings.RoomMusic;
            audioSource.Play();
        }

        FadeController.Instance.FadeOut();
    }

    private IEnumerator ExitRoomSequence()
    {
        FadeController.Instance.FadeIn();
        yield return new WaitForSeconds(1f);

        audioSource.Stop();
        FadeController.Instance.FadeOut();
    }
}