using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed", menuName = "Seed")]
public class Seed : ScriptableObject
{
    public string Name;
    public string[] SpeechText;
}