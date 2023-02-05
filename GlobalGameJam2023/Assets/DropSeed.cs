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
    public string seedName;
    public void ActivateIcon()
    {
        GameManager.Instance.PlayerController.IsTeleporting = true;
        planter.ShowInteractIcon();
        UIManager.Instance.DisplaySpeech( string.Format("You acquired some \"{0}\" seeds",seedName));
        StartCoroutine(HideSpeech(1.2f));
    }

    public IEnumerator HideSpeech(float t)
    {
        yield return new WaitForSeconds(t);
        GameManager.Instance.PlayerController.IsTeleporting = false;

        UIManager.Instance.HideSpeech();
        gameObject.SetActive(false);

    }


}
