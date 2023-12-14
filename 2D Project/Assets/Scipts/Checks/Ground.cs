using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private bool onGround;


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
        
    }



    private void EvaluateCollision(Collision2D collision) 
    {
        for(int i = 0; i < collision.contactCount; i++)
        {
            Vector2 normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.9f;
        }
    }

    public bool GetOnGround()
    {
        return onGround;
    }

    
}
