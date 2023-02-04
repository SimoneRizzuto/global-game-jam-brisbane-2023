using System.Collections;
using System.Collections.Generic;
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

    bool _isNearTeleSpot = false;
    TeleSpot _nearestTeleSpot;


    [SerializeField]
    Planter[] planters;


    //corn = 1
    //chilli = 2
    //pumpkin = 4
    //tomato = 8
    //potato = 16
    //mushroom = 32



    int currentPossessedSeeds = 0;

    [SerializeField] GameObject interactIcon;

    public int CurrentPossessedSeeds
    {
        get
        {
            return currentPossessedSeeds;
        }
    }

    private void Awake()
    {

        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new InputActions();
        playerInputActions.Player.Enable();
        playerAnimator = GetComponent<Animator>();

        playerInputActions.Player.Interact.performed += Interact_performed; ;
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        if (isNearPlanter && nearestPlanter != null)
            nearestPlanter.Interact();

        if (isNearSeed && nearestSeed != null)
        {
            currentPossessedSeeds += nearestSeed.SeedCode;
            nearestSeed.ActivateIcon();
            nearestSeed.gameObject.SetActive(false);
        }

        if (_isNearTeleSpot && _nearestTeleSpot != null) _nearestTeleSpot.StartTeleport();
    }
    void GoToNextDay() //activate near bed
    {
        foreach (var planter in planters)
        {
            if (!planter.AreTasksFinished)
            {
                Debug.Log("Tasks Left to do! Cannot proceed!");
                return;
            }
        }
        foreach (var planter in planters)
        {
            planter.NextDay();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Planter"))
        {
            isNearPlanter = true;
            nearestPlanter = collision.GetComponent<Planter>();
        }

        else if (collision.gameObject.CompareTag("DroppedSeed"))
        {          
            isNearSeed = true;
            nearestSeed = collision.GetComponent<DropSeed>();
            if (!nearestSeed.IsHidden)
                interactIcon.SetActive(true);
            // show icon here for seed
        }

        else if (collision.gameObject.CompareTag("TeleSpot"))
        {
            _isNearTeleSpot = true;
            _nearestTeleSpot = collision.GetComponent<TeleSpot>();
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

        interactIcon.SetActive(false);
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space)) GoToNextDay();
    }

    void Move()
    {
        Vector2 dir = playerInputActions.Player.Move.ReadValue<Vector2>();
        transform.position += (Vector3)dir * Time.deltaTime;

        if (dir.x < 0)
            facing = 0;
        else if (dir.x > 0)
            facing = 1;
        else if (dir.y > 0)
            facing = 2;
        else if (dir.y < 0)
            facing = 3;

        playerAnimator.SetFloat("horizontal", dir.x);
        playerAnimator.SetFloat("vertical", dir.y);
        playerAnimator.SetInteger("direction", facing);
    }

    public void Teleport(Vector3 destination)
    {
        gameObject.transform.position = destination;
    }
}