using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float jumpForce = 18f; // serializeField is ease off the public property and get to edit in unity too
    [SerializeField] float runSpeed = 500f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] AudioSource jumpAudio;
    float dirX;
    Rigidbody2D rb;
    BoxCollider2D collider2D;
    SpriteRenderer spriteRenderer;
    Animator animator;
    bool gamePaused = false;
    private enum MovementState { idle,run,jump,fall}


    // Reference to the Collector script
    private Collector collectorScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // add value to key movement (right = +1 , left = -1)
        dirX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) //jump condition
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
            jumpAudio.Play();
        }

        HandleAnimation();
        PauseGame();
  
    }

    void PauseGame()
    {
         if(Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
        }

        if (gamePaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
    }
  

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX * runSpeed * Time.deltaTime, rb.velocity.y, 0f); //vector3  (x,y,z -> z is of since it is a 2D game)
    }

    bool isGrounded()
    {
        return Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0 , Vector2.down, 0.1f, groundMask);
    }

    void HandleAnimation()
    {
        MovementState state; //declaring state 

        if(dirX > 0) //run
        {
            spriteRenderer.flipX = false;
            state = MovementState.run;
        }
        else if(dirX < 0)
        {
            spriteRenderer.flipX = true;
            state = MovementState.run;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f) //jump and fall
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }


        // after declaring the state must pass to animator in unity to update the state (integer)
        animator.SetInteger("state", (int)state);
    }
}
