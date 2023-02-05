using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public int SpeechIndex = 0; 
    public int DaysOld = 0;

    private string lastEntry = "";

    private List<string> day1 = new List<string>()
    {

    };
    private List<string> day2 = new List<string>()
    {

    };
    private List<string> day3 = new List<string>()
    {

    };
    private List<string> day4 = new List<string>()
    {

    };
    private List<string> day5 = new List<string>()
    {
    };
    private List<string> day7 = new List<string>()
    {

    };
    private List<string> day8 = new List<string>()
    {

    };
    

    public void Interact()
    {
        

        if (UIManager.Instance.IsDisplayed == false)
        {
            UIManager.Instance.DisplaySpeech(lastEntry);
        }
        else UIManager.Instance.HideSpeech();
        
        /*// Plant seed if none in planter
        if (Seed == null && (player.CurrentPossessedSeeds & seedCode) != 0) { Plant(DesignatedSeed); renderer.sprite = planterWithSeed; areTasksFinished = true; }

        // Display or hide watered speech if already watered
        else if (IsWatered)
        {
            if (UIManager.Instance.IsDisplayed == false) { UIManager.Instance.DisplaySpeech(lastSpeech); }
            else UIManager.Instance.HideSpeech();
        }

        // Display or hide normal speech if not watered
        else Talk();*/

        //ShowInteractIcon();
    }

    void Read()
    {
    }
    
    
    /*public void ShowInteractIcon()
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
    }*/
}
