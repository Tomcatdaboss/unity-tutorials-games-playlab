// NOTE: This script uses the 'new' input system, which has been standard since Unity 6.
// Any tutorials from before 2025 or so will likely not use this input system.
// I can show you how to use the old input system in your project - just reach out!

// this is where we import packages. Packages are basically bits of code written by other programmers (in this case Unity) that we use to define and use more advanced bits of code, in this case the input system.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement2D : MonoBehaviour
{
    // this section of the script is where the different variables are initialised.
    // To initialise variables in C#, you write <access level> <variable type> <variable name> = <variable value>, as shown below:
    private CustomInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null; // The rigidbody is basically the component that lets the game object it is attached to experience physics, e.g gravity, bouncing off other objects, etc.
    private float moveSpeed = 10f;
    // The Awake function is called when this script is activated for the first time, e.g upon the start of the game.
    private void Awake()
    {  
        // this code is basically just assigning values to the two variables that we previously left as null.
        input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
    }
    // this OnEnable function is called every time the script is activated in game, not just on start.
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCanceled;
    }
    // this OnDisable function is called every time the script is de-activated in game
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCanceled;
    }
    // The fixed update function is called many times per second, similar to the standard Update() function that is provided with new scripts, but rather than being called every frame, it's called every 1/50th of a second no matter what, making it useful for physics calculations.
    private void FixedUpdate()
    { // every fraction of a second, this line below takes the movement vector (which we got from the input system below) and the move speed (provided by the player) and provides a linear velocity vector to the player rigidbody, making it actually move.
        rb.linearVelocity = moveSpeed * moveVector;
    }
    // this function accepts a new value from the input system and assigns it as the movement direction every time the player moves (or inputs to the specified input system instance, if you want a more general definition)
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();   
    }
    // this function sets the player's movement to zero every time the player stops moving/inputting WASD
    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}
