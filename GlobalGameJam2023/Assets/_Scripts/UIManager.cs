using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Singleton
    public static UIManager Instance;

    // UI Elements
    public GameObject SpeechTextBox;
    public TMP_Text SpeechText;
    public Animator FadeTransitionAnimator;
    public GameObject Credits;

    public bool IsDisplayed {get; private set;}

    public void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        IsDisplayed = false;
    }

    public void DisplaySpeech(string content)
    {
        SpeechText.text = content;
        SpeechTextBox.SetActive(true);
        IsDisplayed = true;
    }

    //Adrian - can someone tell me why the f this was in the player controller?
    public IEnumerator HideSpeechTimer(float t)
    {
        yield return new WaitForSeconds(t);
        UIManager.Instance.HideSpeech();
    }

    public void HideSpeech()
    {
        SpeechTextBox.SetActive(false);
        IsDisplayed = false;
    } 
}