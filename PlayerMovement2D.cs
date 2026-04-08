// NOTE: This script uses the 'old' input system, which has not been standard since Unity 6.
// Any tutorials from after 2025 or so will likely not use this input system.


// this is where we import packages. Packages are basically bits of code written by other programmers (in this case Unity) that we use to define and use more advanced bits of code.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement2D : MonoBehaviour
{
    // this section of the script is where the different variables are initialised.
    // To initialise variables in C#, you write <access level> <variable type> <variable name> = <variable value>, as shown below:
    private Rigidbody2D player = null; // The rigidbody is basically the component that lets the game object it is attached to experience physics, e.g gravity, bouncing off other objects, etc.
    private float moveSpeed = 10f;
    private float jumpHeight = 5f;
    private bool is_on_ground = false;
    // The Start function is called when this script is activated for the first time, e.g upon the start of the game.
    void Start()
    { 
       // this code is basically just assigning values to the variable that we previously left as null.
       player = GetComponent<Rigidbody2D>();
    }
    // this Update function is called every frame, making it the main function you will code in.
    void Update()
    { // this line of code takes input from the horizontal axis (A and D keys) and uses it to set the player's velocity via the rigidbody component.
        player.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, player.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && is_on_ground)
        {  // this if statement checks if the player pressed space whilst on the ground and if so, lets them jump.
            player.linearVelocity = new Vector2(player.linearVelocity.x, jumpHeight);
        }
    }
    void OnCollisionEnter2D(Collision2D col) // this method is called whenever the player object contacts another gameobject with a collider.
    {
        if (col.gameObject.layer == 3) // this if statement checks if the collider you have hit belongs to a gameobject on the 3rd layer (in my tutorial this was our ground layer)
        { // THE LINE ABOVE MAY NEED TO BE CHANGED DEPENDING ON WHAT LAYER NUMBER YOU HAVE ASSIGNED TO "GROUND"
            is_on_ground = true;
        }  
    }
    void OnCollisionExit2D(Collision2D col) // this method is called whenever the player object breaks contact with another gameobject with a collider.
    {
        if (col.gameObject.layer == 3) // this if statement checks if the collider you have hit belongs to a gameobject on the 3rd layer (in my tutorial this was our ground layer)
        {// THE LINE ABOVE MAY NEED TO BE CHANGED DEPENDING ON WHAT LAYER NUMBER YOU HAVE ASSIGNED TO "GROUND"
            is_on_ground = false;
        } 
    }
}
