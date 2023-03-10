using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : MonoBehaviour
{
    public Seed Seed; // not set in editor

    public Seed DesignatedSeed; // for testing purposes

    public int seedCode = 1; //for corn is 1 ( see refer at playercontroller )


    public int SpeechIndex = 0; // starts at zero -- probs private?

    public bool IsWatered = false; // starts at false -- probs private with public method?

    public int DaysOld = 0;

    [SerializeField]
    GameObject seedIcon, waterIcon;

    [SerializeField]
    Sprite planterWithSeed;
    SpriteRenderer renderer;

    bool areTasksFinished = false;
    PlayerController player;

    public bool AreTasksFinished { get => areTasksFinished; }
    string speech = "";

    string lastSpeech = "";
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        renderer = GetComponent<SpriteRenderer>();
        ShowInteractIcon();

        if (DesignatedSeed.StartDay > player.CurrentDay)
        {
            areTasksFinished = true;
        }

    }

    public void NextDay()
    {
        
        if(Seed != null) { renderer.sprite = Seed.finalImage; DaysOld++; }

        SpeechIndex = 0;
    
        IsWatered = false;
        areTasksFinished = false;
        ShowInteractIcon();

        if(DesignatedSeed.StartDay > player.CurrentDay)
        {
            areTasksFinished = true;
        }
    }

    public void Interact()
    {
        // Plant seed if none in planter
        if (Seed == null && (player.CurrentPossessedSeeds & seedCode) != 0) { Plant(DesignatedSeed); renderer.sprite = planterWithSeed; areTasksFinished = true; }

        // Display or hide watered speech if already watered
        else if (IsWatered)
        {
            if (UIManager.Instance.IsDisplayed == false) { UIManager.Instance.DisplaySpeech(lastSpeech); }
            else UIManager.Instance.HideSpeech();
        }

        // Display or hide normal speech if not watered (Adrian - and not a limp seed)
        else if (DaysOld != 0) Talk();

        ShowInteractIcon();
    }

    public void ShowInteractIcon()
    {
        
        if (Seed == null && (player.CurrentPossessedSeeds & seedCode) != 0 && DesignatedSeed.StartDay == player.CurrentDay)
        {
            waterIcon.SetActive(false);
            seedIcon.SetActive(true);
        }
        else if (IsWatered)
        {
            waterIcon.SetActive(false);
            seedIcon.SetActive(false);
        }
        else 
        {
            if (DaysOld != 0 && DesignatedSeed.StartDay <= player.CurrentDay)
            {
                waterIcon.SetActive(true);
                seedIcon.SetActive(false);
            }
            else
            {
                waterIcon.SetActive(false);
                seedIcon.SetActive(false);
            }
        }


    }

    void Plant(Seed seed)
    {
        Seed = seed;
        FindObjectOfType<AudioManager>().Play("Plant Seeds");
        SpeechIndex = 0;
    }

    void Talk()
    {
        // Set speech string
        bool isDoneTalking = false;
        player.IsTeleporting = true; //Adrian - you can't run away from them or else they'll [REDACTED] /jk
        switch (DaysOld)
        {
            case 1:
                if (SpeechIndex == Seed.Day1.Length) { isDoneTalking = true; if( player.CurrentDay == Seed.StartDay+1 ) player.HintKnow = true; }
                else speech = Seed.Day1[SpeechIndex];
                break;
            case 2:
                if (SpeechIndex == Seed.Day2.Length) { isDoneTalking = true; if (player.CurrentDay == Seed.StartDay + 1) player.HintKnow = true; }
                else speech = Seed.Day2[SpeechIndex];
                break;
            case 3:
                if (SpeechIndex == Seed.Day3.Length) { isDoneTalking = true; if (player.CurrentDay == Seed.StartDay + 1) player.HintKnow = true; }
                else speech = Seed.Day3[SpeechIndex];
                break;
            case 4:
                if (SpeechIndex == Seed.Day4.Length) { isDoneTalking = true; if (player.CurrentDay == Seed.StartDay + 1) player.HintKnow = true; }
                else speech = Seed.Day4[SpeechIndex];
                break;
            case 5:
                if (SpeechIndex == Seed.Day5.Length) { isDoneTalking = true; if (player.CurrentDay == Seed.StartDay + 1) player.HintKnow = true; }
                else speech = Seed.Day5[SpeechIndex];
                break;
            case 6:
                if (SpeechIndex == Seed.Day6.Length) { isDoneTalking = true; if (player.CurrentDay == Seed.StartDay + 1) player.HintKnow = true; }
                else speech = Seed.Day6[SpeechIndex];
                break;
            case 7:
                if (SpeechIndex == Seed.Day7.Length) { isDoneTalking = true; if (player.CurrentDay == Seed.StartDay + 1) player.HintKnow = true; }
                else speech = Seed.Day7[SpeechIndex];
                break;
            default:
                speech = "Day not found oopsies";
                break;
        }
        lastSpeech = speech;
        // Display or hide speech
        if (isDoneTalking)
        {
            UIManager.Instance.HideSpeech();
            areTasksFinished = true;
            FindObjectOfType<AudioManager>().Play("Water Plant");
            IsWatered = true;
            player.IsTeleporting = false; //we're free!
        }
        else
        {
            UIManager.Instance.DisplaySpeech(speech);
            SpeechIndex++;
        }
    }
}