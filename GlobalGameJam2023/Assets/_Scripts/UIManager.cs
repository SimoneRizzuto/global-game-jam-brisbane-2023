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

    public void DisplaySpeech(string content)
    {
        SpeechText.text = content;
        SpeechTextBox.SetActive(true);
    }

    public void HideSpeech()
    {
        SpeechTextBox.SetActive(false);
    }
}