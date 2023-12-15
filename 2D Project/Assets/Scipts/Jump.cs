using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 20f)] private float jumpHeight = 13.3f;
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 4f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 4.5f;

    private Rigidbody2D body;
    private Ground ground;
    private Vector2 velocity;

    
    private float defaultGravityScale;

    private bool desiredJump;
    private bool onGround;

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

        

        if(desiredJump) 
        {
            desiredJump = false;
            JumpAction();
        }

        if(body.velocity.y > 0)
        {
            body.gravityScale = upwardMovementMultiplier;
        }
        else if (body.velocity.y < 0)
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
        if (onGround)
        {
            float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);  
            }
            velocity.y += jumpSpeed;
        }
    }
#endif
}
