using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 6.5f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 80f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 60f;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Animator anim;
    private Ground ground;
    private bool isFacingRight = true;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;

#if game_feel
    // Start is called before the first frame update
    void Awake()
    {
        body.GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
    }


    // Update is called once per frame
    void Update()
    {
        direction.x = input.RetrieveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed, 0);

        Flip();
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        body.velocity = velocity;


        if (direction.x > 0f)
        {
            anim.SetBool("isRunning", true);
        }
        else if (direction.x < 0f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (onGround)
        {
            anim.SetBool("isJumping", false);
        }

        else if (!onGround) 
        {
            anim.SetBool("isJumping", true);
        }

}

private void Flip()
    {
        if (isFacingRight && direction.x < 0f || !isFacingRight && direction.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }

    }
#endif
}
