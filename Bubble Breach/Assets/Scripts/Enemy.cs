using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private CircleCollider2D exitCollider;
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;
    private Transform player;
    private bool canFollow = false;
    [Header("Shooting")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float startTimeBtwShots;
    private float timeBtwShots;
    private bool firstTime;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canFollow)
        {
            if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if(timeBtwShots <= 0)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            firstTime = true;
            canFollow = true;
            exitCollider.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player") && !firstTime)
        {
            firstTime = true;
            canFollow = false;
            exitCollider.enabled = false;
        }
        else if(collider.gameObject.CompareTag("Player") && firstTime)
        {
            firstTime = false;
        }
    }
}
