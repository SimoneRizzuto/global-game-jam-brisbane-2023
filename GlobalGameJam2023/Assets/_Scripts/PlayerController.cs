using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    InputActions playerInputActions;
    Animator playerAnimator;

    int facing = 3; // for default - down

    bool isNearPlanter = false;
    Planter nearestPlanter;

    bool isNearSeed = false;
    DropSeed nearestSeed;

    private bool isNearDiary = false;
    [SerializeField]
    Diary diary;
    
    bool _isNearTeleSpot = false;
    TeleSpot _nearestTeleSpot;

    public bool IsTeleporting = false;

    [SerializeField]
    Planter[] planters;

    int currentDay = 1;

    //corn = 1
    //chilli = 2
    //pumpkin = 4
    //tomato = 8
    //potato = 16
    //mushroom = 32

    bool hintKnow = true;

    int currentPossessedSeeds = 0;

    [SerializeField] GameObject interactIcon;
    [SerializeField] GameObject sleepIcon;

    public int CurrentPossessedSeeds
    {
        get
        {
            return currentPossessedSeeds;
        }
    }

    public int CurrentDay { get => currentDay; }
    public bool HintKnow { get => hintKnow; set => hintKnow = value; }

    private void Awake()
    {

        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new InputActions();
        playerInputActions.Player.Enable();
        playerAnimator = GetComponent<Animator>();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        if (isNearDiary)
        {
            diary.Interact();
        }
        
        if (isNearPlanter && nearestPlanter != null)
            nearestPlanter.Interact();

        if (isNearSeed && nearestSeed != null)
        {
            if (CurrentDay == nearestSeed.ActivationDay && HintKnow)
            {
                currentPossessedSeeds += nearestSeed.SeedCode;
                nearestSeed.ActivateIcon();
                nearestSeed.gameObject.SetActive(false);
            }

        }
        if(sleepIcon.activeInHierarchy)
        {
            GoToNextDay();
        }
        
        //if (_isNearTeleSpot && _nearestTeleSpot != null) _nearestTeleSpot.StartTeleport();
    }
    void GoToNextDay() //activate near bed
    {
        foreach (var planter in planters)
        {
            if (!planter.AreTasksFinished)
            {
                UIManager.Instance.DisplaySpeech("It is still early!");
                StartCoroutine(HideSpeech(1.2f));
                return;
            }
        }
        currentDay++;
        HintKnow = false;
        foreach (var planter in planters)
        {
            planter.NextDay();
        }
    }

    IEnumerator HideSpeech(float t)
    {
         yield return new WaitForSeconds(t);
         UIManager.Instance.HideSpeech();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Diary"))
        {
            isNearDiary = true;
        }
    
        if (collision.gameObject.CompareTag("Planter"))
        {
            isNearPlanter = true;
            nearestPlanter = collision.GetComponent<Planter>();
        }

        else if (collision.gameObject.CompareTag("DroppedSeed"))
        {
            isNearSeed = true;
            nearestSeed = collision.GetComponent<DropSeed>();
            if (CurrentDay == nearestSeed.ActivationDay && HintKnow)
            {
                if (!nearestSeed.IsHidden)
                    interactIcon.SetActive(true);
            }
            // show icon here for seed
        }
        else if (collision.gameObject.CompareTag("Bed"))
        {

            sleepIcon.SetActive(true);

            // show icon here for seed
        }

        else if (collision.gameObject.CompareTag("TeleSpot"))
        {
            _isNearTeleSpot = true;
            _nearestTeleSpot = collision.GetComponent<TeleSpot>();
            _nearestTeleSpot.StartTeleport();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearPlanter = false;
        nearestPlanter = null;

        isNearSeed = false;
        nearestSeed = null;

        _isNearTeleSpot = false;
        _nearestTeleSpot = null;
        
        isNearDiary = false;

        interactIcon.SetActive(false);
        sleepIcon.SetActive(false);
    }

    private void FixedUpdate()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space)) GoToNextDay();
    }

    void Move()
    {
        Vector2 dir;
        if (IsTeleporting) { dir = Vector2.zero; }

        else
        {
            dir = playerInputActions.Player.Move.ReadValue<Vector2>();
            if (Mathf.Abs(dir.x) > 0.05) { dir.x = 1 * Mathf.Sign(dir.x); }
            if (Mathf.Abs(dir.y) > 0.05) { dir.y = 1 * Mathf.Sign(dir.y); }


            if (dir.x < 0)
                facing = 0;
            else if (dir.x > 0)
                facing = 1;
            else if (dir.y > 0)
                facing = 2;
            else if (dir.y < 0)
                facing = 3;
            playerAnimator.SetInteger("direction", facing);


        }

        playerAnimator.SetFloat("horizontal", dir.x);
        playerAnimator.SetFloat("vertical", dir.y);

        transform.position += ((Vector3)dir).normalized * Time.deltaTime;

    }

    public void Teleport(Vector3 destination)
    {
        gameObject.transform.position = destination;
    }
}