using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    
    [SerializeField] float duration = 1f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform respawnPoint;
    [SerializeField] Animator fadeAnimator;


#if game_feel

    // Start is called before the first frame update



    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }



    IEnumerator Respawn(float duration)
    {
        rb.simulated = false;
        fadeAnimator.SetBool("ShouldFade", true);
        yield return new WaitForSeconds(duration);
        fadeAnimator.SetBool("ShouldFade", false);
        transform.position = respawnPoint.position;
        rb.simulated = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hazard")
        {

            Die();
        }
    }

#endif

#if no_feel
    [SerializeField] Transform respawnPoint;

    private void Respawn()
    {
        transform.position = respawnPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hazard")
        {

            Respawn();


            


        }
        
    }
#endif


}










