using UnityEngine;

/// <summary>
/// Submenu
/// 
/// Adrian Barrett
/// 
/// A script for changing and hiding various layers of menus.
/// Place it on the main canvas/panel of the submenu
/// Built off the PauseMenu script.
/// </summary>

public class Submenu : MonoBehaviour
{
    public bool SubMenuOpen = false;

    //CurrentUI - the UI that this script opens the submenu over/on
    public GameObject currentUI;
    //SubMenuUI - the submenu to open using this script
    public GameObject subMenuUI;

    void Start()
    {
        //For those that forget or don't want to set this
        subMenuUI = gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SubMenuOpen)
            {
                //escape to also be used to back out of a submenu
                Close();
            }
        }
    }
    //Close submenu
    public void Close()
    {
        subMenuUI.SetActive(false);
        currentUI.SetActive(true);
        SubMenuOpen = false;
    }
    //Open submenu
    public void Open()
    {
        subMenuUI.SetActive(true);
        currentUI.SetActive(false);
        SubMenuOpen = true;
    }
}
