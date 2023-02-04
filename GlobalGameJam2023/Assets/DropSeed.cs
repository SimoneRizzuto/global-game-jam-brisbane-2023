using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSeed : MonoBehaviour
{
    //refer playercontroller for seedCode
    //edit in the editor
    public int SeedCode = 1;

    [SerializeField] Planter planter;

    public void ActivateIcon()
    {
        planter.ShowInteractIcon();
    }
}
