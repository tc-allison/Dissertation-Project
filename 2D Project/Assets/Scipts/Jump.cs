using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 20f)] private float jumpHeight = 13.3f;
    [SerializeField, Range(0f, 10f)] private float downwardMovementMultiplier = 4f;
    [SerializeField, Range(0f, 10f)] private float upwardMovementMultiplier = 4.5f;
    [SerializeField, Range(0f, 0.3f)] private float coyoteTime = 0.2f;
    [SerializeField, Range(0f, 0.3f)] private float jumpBufferTime = 0.2f;

    private Rigidbody2D body;
    private Ground ground;
    private Vector2 velocity;

    
    private float defaultGravityScale, coyoteCounter, jumpSpeed, jumpBufferCounter;

    private bool desiredJump, onGround, isJumping;
    

#if game_feel
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();

        defaultGravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        desiredJump |= input.RetrieveJumpInput();

       
        
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        if (onGround && body.velocity.y == 0)
        {
            coyoteCounter = coyoteTime;
        }
        else
        {
            coyoteCounter -= Time.deltaTime;
        }

        if(desiredJump) 
        {
            desiredJump = false;
            jumpBufferCounter = jumpBufferTime;
        }
        else if (!desiredJump && jumpBufferCounter > 0) 
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0)
        {
            JumpAction();
        }


        if(input.RetrieveJumpHoldInput() && body.velocity.y > 0)
        {
            body.gravityScale = upwardMovementMultiplier;
        }
        else if (!input.RetrieveJumpHoldInput() || body.velocity.y < 0)
        {
            body.gravityScale = downwardMovementMultiplier;
        }

        else if (body.velocity.y == 0)
        {
            body.gravityScale = defaultGravityScale;
        }

        body.velocity = velocity;
    }


    private void JumpAction()
    {
        if (coyoteCounter > 0f)
        {
            jumpBufferCounter = 0;
            coyoteCounter = 0f;
            jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);  
            }
            velocity.y += jumpSpeed;
        }
    }
#endif
}
