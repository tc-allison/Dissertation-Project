using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    // Start is called before the first frame update



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
}
