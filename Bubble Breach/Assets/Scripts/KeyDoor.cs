using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            var playerScript = collision.gameObject.GetComponent<Player>();
            if(playerScript.key != null)
            {
                Destroy(playerScript.key);
                playerScript.key = null;
                Destroy(gameObject);
            } else {
                playerScript.KillPlayer();
            }
        }
    }
}
