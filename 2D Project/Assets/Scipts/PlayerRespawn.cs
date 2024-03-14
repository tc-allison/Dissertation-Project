using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
#if game_feel
    
    [SerializeField] float duration = 1f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform respawnPoint;
    public bool playFade;

    // Start is called before the first frame update



    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }



    IEnumerator Respawn(float duration)
    {
        rb.simulated = false;
        playFade = true;
        yield return new WaitForSeconds(duration);
        transform.position = respawnPoint.position;
        rb.simulated = true;
        playFade = false;
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










