using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public int SpeechIndex = 0; 
    public int DaysOld = 0;
    [SerializeField]
    private PlayerController player;
    
    private string lastEntry = "";

    private List<string> day1 = new List<string>()
    {
        "Grandma left her garden after she passed. She seemed comfortable with her life ending. I hope she passed peacefully.",
        "I really wish I was here for her. I can’t imagine spending your last days alone.",
        "I found a packet of seeds outside. I planted them, it’s the first step into giving this garden life."
    };
    private List<string> day2 = new List<string>()
    {
        "That seed that I planted grew into a corn plant. How did grandma put up with all his jokes? They’re so bad.",
        "I found more seeds today. I hope they’re better company."
    };
    private List<string> day3 = new List<string>()
    {
        "That chilli complains about everything.It’s really annoying. But I hope he can maybe teach me Spanish, that would be nice.",
        "I wonder how many plants Grandma had. I hope they all have something to say about her. It makes me feel closer to her, like she’s still here."
    };
    private List<string> day4 = new List<string>()
    {
        "Today I learnt a bit about Grandpa. I didn’t know he was a Colonel. I never really learned much about him.",
        "All I ever heard was the stories of how he was with Grandma before I came. I hope corn wasn’t joking about him.",
        "Chilli spoke about his father which had a nickname that was in Spanish ‘Picante de Volcan’ I wonder what it means.",
        "I also met Pumpkin today. He seems like the most level headed of all the plants. Apparently, Grandma used to talk to the plants about me.",
        "It’s still a little weird talking to plants, but they’re starting to grow on me."
    };
    private List<string> day5 = new List<string>()
    {
        "Chilli was complaining about Pumpkin having a weird last name. But I learnt some Spanish. ‘Estupido’, from context I gather it means stupid.",
        "But I do think Pumpkin was into some shady stuff previously. He said something about splitting melons, I’m glad grandma got him out of it.",
        "I met Tomato today she was talking about her brother most of the day.",
        "I hope I meet him soon. Mostly so Tomato stops talking about him."
    };
    private List<string> day6 = new List<string>()
    {
        "Tomato’s still annoying even with her brother there, but Potato is a very chill and responsible guy, Irish too. I’ve never met anyone from there.",
        "Chilli was steaming today. It was about grandma leaving without saying goodbye. The plants wouldn't have been watered around that time either. Poor things.",
        "Pumpkins full name is Jack O'Lantern, pretty spooky. Should I tell Chilli? Would be pretty funny."
    };
    private List<string> day7 = new List<string>()
    {
        "Today I learnt that Chilli is Potato and Tomato’s uncle, wow that family really crosses the world.",
        "Pumpkin quoted a something menacing at me I think I have heard it in a movie somewhere.",
        "Mushroom is a little weird but nice I think he is trying to take over the world, I don’t think he will but he’s a pretty fungi, DAMNIT Corn you’ve infected me with your jokes.",
        "Tomato has only just learnt my name which is a step up from being called a lot of different names yesterday, even though one of them is my Mother’s name.",
        "Maple.",
        "I really do miss her."
    };
    private List<string> day8 = new List<string>()
    {
        "Everyone is is talking about Grandma today they all speak of here in such an amazing light, she really has a positive effect on everyone here.",
        "Except Mushroom but I don’t think he has realised that Grandma is gone but he’s still planning out world domination, but I think it’ll take awhile for it to happen.",
        "It makes me feel a lil reminiscent with everyone talking about grandma.",
        "Thinking about all the times that I came here as a kid and never realised all the plants talked.",
        "Although it now makes sense with all the weird sounds that I heard."
    };
    

    public void Interact()
    {
        if (player.CurrentDay == 1)
        {
            if (SpeechIndex < day1.Count)
            {
                UIManager.Instance.DisplaySpeech(day1[SpeechIndex]);
                SpeechIndex++;
                return;
            }
        }
        else if (player.CurrentDay < 2)
        {
            if (SpeechIndex == day2.Count)
            {
                UIManager.Instance.DisplaySpeech(day2[SpeechIndex]);
                SpeechIndex++;
                return;
            }
        }
        else if (player.CurrentDay < 3)
        {
            if (SpeechIndex == day3.Count)
            {
                SpeechIndex = 0;
                UIManager.Instance.HideSpeech();
                return;
            }
        }
        else if (player.CurrentDay < 4)
        {
            if (SpeechIndex == day4.Count)
            {
                SpeechIndex = 0;
                UIManager.Instance.HideSpeech();
                return;
            }
        }
        else if (player.CurrentDay < 5)
        {
            if (SpeechIndex == day5.Count)
            {
                SpeechIndex = 0;
                UIManager.Instance.HideSpeech();
                return;
            }
        }
        else if (player.CurrentDay < 6)
        {
            if (SpeechIndex == day6.Count)
            {
                SpeechIndex = 0;
                UIManager.Instance.HideSpeech();
                return;
            }
        }
        else if (player.CurrentDay < 7)
        {
            if (SpeechIndex == day7.Count)
            {
                SpeechIndex = 0;
                UIManager.Instance.HideSpeech();
                return;
            }
        }
        else if (player.CurrentDay < 8)
        {
            if (SpeechIndex == day8.Count)
            {
                SpeechIndex = 0;
                UIManager.Instance.HideSpeech();
                return;
            }
        }
        
        SpeechIndex = 0;
        UIManager.Instance.HideSpeech();
    }
}
