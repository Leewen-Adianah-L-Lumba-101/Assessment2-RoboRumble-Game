using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Variables for referencing the grid movement the Player will have
    public float moveSpeed = 0.5f;
    public Transform movePoint;
    public Animator anim;
    public Transform attackarea;

    // Vector for storing keyboard input
    Vector2 movement;

    // Prevent players from moving outside of movement grids
    public LayerMask whatStopsMovement;


    // Start is called before the first frame update
    void Start()
    {
        // In Unity there is a child GameObject (attached to the parent Player GameObject),
        // called the movePoint, it focuses on the next grid 
        // the player will move to, once the program starts it will remove itself from the Player parent GameObject
        // Making sure it is unaffected by the Player's scripts and etc...
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal movements of the user, from keyboard, it is converted to axis floats
        movement.x = Input.GetAxisRaw("Horizontal");

        // Make sure the animations are played properly, in the right directions
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        // Player moves towards the movePoint, as it places itself on the grids of the tilemap.
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        // Make sure the distance between the movePoint and Player transform is less than or equal to .05
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            // Check if axis values for horizontal are equal to a specific amount, this will make sure the movePoint moves at 
            // a consistent range.
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                // Move movePoint, stop the movePoint when it hits a collider object.
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }

            // Makes sure there is only vertical movement or horizontal movement, preventing diagonals
            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

        // This condition simply makes sure the animations are playing idles in the correct direction. If the player dashes to the left, the idle playing should have
        // the character facing the left side.
        if ((Input.GetAxisRaw("Horizontal")) == 1f || Input.GetAxisRaw("Horizontal") == -1f)
            {
                anim.SetFloat("lastMovement", Input.GetAxisRaw("Horizontal"));
                attackarea.transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            }
        }
    }
}
