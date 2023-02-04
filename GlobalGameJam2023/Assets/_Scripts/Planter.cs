using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : MonoBehaviour
{
    public Seed Seed; // not set in editor
    public Seed TestSeed; // for testing purposes

    public int SpeechIndex = 0; // starts at zero -- probs private?

    public bool IsWatered = false; // starts at false -- probs private with public method?

    public int DaysOld = 0;

    public void NextDay()
    {
        SpeechIndex = 0;
        DaysOld++;
    }

    public void Interact()
    {
        // Plant seed if none in planter
        if (Seed == null) Plant(TestSeed);

        // Display or hide watered speech if already watered
        else if (IsWatered) 
        {
            if (UIManager.Instance.IsDisplayed) UIManager.Instance.DisplaySpeech(Seed.WateredText);
            else UIManager.Instance.HideSpeech();
        }

        // Display or hide normal speech if not watered
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
        string speech = "";
        bool isDoneTalking = false;
        switch (DaysOld)
        {
            case 0:
                if (SpeechIndex == Seed.Day1.Length) isDoneTalking = true;
                else speech = Seed.Day1[SpeechIndex];
                break;
            case 1:
                if (SpeechIndex == Seed.Day2.Length) isDoneTalking = true;
                else speech = Seed.Day2[SpeechIndex];
                break;
            case 2:
                if (SpeechIndex == Seed.Day3.Length) isDoneTalking = true;
                else speech = Seed.Day3[SpeechIndex];
                break;
            case 3:
                if (SpeechIndex == Seed.Day4.Length) isDoneTalking = true;
                else speech = Seed.Day4[SpeechIndex];
                break;
            case 4:
                if (SpeechIndex == Seed.Day5.Length) isDoneTalking = true;
                else speech = Seed.Day5[SpeechIndex];
                break;
            case 5:
                if (SpeechIndex == Seed.Day6.Length) isDoneTalking = true;
                else speech = Seed.Day6[SpeechIndex];
                break;
            case 6:
                if (SpeechIndex == Seed.Day7.Length) isDoneTalking = true;
                else speech = Seed.Day7[SpeechIndex];
                break;
            default:
                speech = "Day not found oopsies";
                break;
        }

        // Display or hide speech
        if (isDoneTalking)
        {
            UIManager.Instance.HideSpeech();
            IsWatered = true;
        }
        else
        {
            UIManager.Instance.DisplaySpeech(speech);
            SpeechIndex++;
        }
    }
}