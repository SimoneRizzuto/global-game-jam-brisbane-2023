using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconPopup : MonoBehaviour
{
    [SerializeField] GameObject waterIcon;
    [SerializeField] GameObject seedIcon;

    public GameObject WaterIcon { get => waterIcon;}
    public GameObject SeedIcon { get => seedIcon; }
}
