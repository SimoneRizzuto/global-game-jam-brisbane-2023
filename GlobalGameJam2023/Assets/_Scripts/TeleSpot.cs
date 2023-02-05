using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleSpot : MonoBehaviour
{
    [SerializeField]
    GameObject[] cameras;
    public AudioSource BGMusic;
    [SerializeField] GameObject activatedCamera;

    public GameObject Destination;

    float _teleportDelay = 1.5f;

    public void StartTeleport()
    {
        UIManager.Instance.FadeTransitionAnimator.SetBool("IsFading", true);
        Invoke(nameof(Teleport), _teleportDelay);
        GameManager.Instance.PlayerController.IsTeleporting = true;
    }

    void Teleport()
    {
        foreach (var cam in cameras) { cam.SetActive(false); }
        activatedCamera.SetActive(true);
        GameManager.Instance.PlayerController.IsTeleporting = false;
        GameManager.Instance.PlayerController.Teleport(Destination.transform.position);
        UIManager.Instance.FadeTransitionAnimator.SetBool("IsFading", false);
        StopAllAudio();
        BGMusic.Play();
    }
    private AudioSource[] allAudioSources;

    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
}