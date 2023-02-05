using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleSpot : MonoBehaviour
{
    [SerializeField]
    GameObject[] cameras;

    [SerializeField] GameObject activatedCamera;

    public GameObject Destination;

    float _teleportDelay = 1.25f;

    public void StartTeleport()
    {
        UIManager.Instance.FadeTransitionAnimator.SetBool("IsFading", true);
        Invoke(nameof(Teleport), _teleportDelay);
    }

    void Teleport()
    {
        foreach (var cam in cameras) { cam.SetActive(false); }
        activatedCamera.SetActive(true);
        GameManager.Instance.PlayerController.Teleport(Destination.transform.position);
        UIManager.Instance.FadeTransitionAnimator.SetBool("IsFading", false);
    }
}