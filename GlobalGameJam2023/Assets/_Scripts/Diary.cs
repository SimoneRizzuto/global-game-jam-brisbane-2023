using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public int SpeechIndex = 0; 
    public int DaysOld = 0;

    private string lastEntry = "testing 123";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Read();
        
        if (UIManager.Instance.IsDisplayed == false) { UIManager.Instance.DisplaySpeech(lastEntry); }
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
