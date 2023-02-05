using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExittoMenuTrigger : MonoBehaviour
{
    public PauseMenu pauseMenu;


    private void OnTriggerEnter2D(Collider2D collision)
    {
   pauseMenu.Pause();
    }

}
