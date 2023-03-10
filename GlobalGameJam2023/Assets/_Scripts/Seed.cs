using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed", menuName = "Seed")]
public class Seed : ScriptableObject
{
    public int StartDay;

    public string Name;


    public string[] Day1, Day2, Day3, Day4, Day5, Day6, Day7;

    public Sprite finalImage;
}