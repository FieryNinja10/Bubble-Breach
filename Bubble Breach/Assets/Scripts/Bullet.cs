using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject dieParticles;
    private Transform player;
    private Vector2 target;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //gameObject.AddComponent<CircleCollider2D>();
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            dieParticles.SetActive(true);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            var playerScript = collider.gameObject.GetComponent<Player>();
            playerScript.KillPlayer();

            dieParticles.SetActive(true);
            Destroy(gameObject);
        }
        else if(collider.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        else if(collider.gameObject.CompareTag("Untagged"))
        {
            DestroyObj();
        }
    }

    IEnumerator AddCollider()
    {
        int i = 0;
        yield return new WaitForSeconds(0.01f);
        gameObject.AddComponent<CircleCollider2D>();
    }

    void DestroyObj()
    {
        Instantiate(dieParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
