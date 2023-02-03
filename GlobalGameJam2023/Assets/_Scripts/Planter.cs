using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : MonoBehaviour
{
    public Seed Seed; // not set in editor
    public int SpeechIndex = 0; // starts at zero

    public Seed TestSeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    public void Interact()
    {

        if (Seed == null) Plant(TestSeed);
        else Talk();

    }

    void Plant(Seed seed)
    {
        Seed = seed;
        SpeechIndex = 0;
    }

    void Talk()
    {
        // Set speech string
        string speech = Seed.SpeechText[SpeechIndex];
        SpeechIndex++;

        // Display speech
        UIManager.Instance.DisplaySpeech(speech);
    }
}