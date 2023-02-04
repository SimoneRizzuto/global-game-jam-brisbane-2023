using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSeed : MonoBehaviour
{
    //refer playercontroller for seedCode
    //edit in the editor
    public int SeedCode = 1;
    public int ActivationDay = 0;
    [SerializeField] Planter planter;

    public bool IsHidden = false;
    public void ActivateIcon()
    {
        planter.ShowInteractIcon();
    }
}
