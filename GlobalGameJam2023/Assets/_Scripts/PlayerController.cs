using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    InputActions playerInputActions;
    Animator playerAnimator;

    int facing = 3; // for default - down

    bool isNearPlanter = false;
    Planter nearestPlanter; 

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new InputActions();
        playerInputActions.Player.Enable();
        playerAnimator= GetComponent<Animator>();

        playerInputActions.Player.Interact.performed += Interact_performed; ;
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        if (isNearPlanter && nearestPlanter != null)
            nearestPlanter.Interact();       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isNearPlanter =true;
        nearestPlanter = collision.GetComponent<Planter>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearPlanter =false;
        nearestPlanter = null;
    }


    private void Update()
    {
        Move();
    }
   
    


    void Move()
    {
        Vector2 dir = playerInputActions.Player.Move.ReadValue<Vector2>();
        transform.position +=  (Vector3)dir * Time.deltaTime;
        //Debug.Log(dir);


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
        playerAnimator.SetInteger("direction", facing) ;

    }
}



