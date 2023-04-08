using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject popParticles;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject shield;
    public static bool canMove = false;
    public GameObject key = null;
    private Animator anim;

    void Awake()
    {
        Time.timeScale = 1;
        anim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        // Code goes here...
    }

    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if(canMove)
        {
            transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if(key != null)
        {
            key.transform.position = transform.position - new Vector3(0.5f, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Untagged") || collision.gameObject.CompareTag("Enemy"))
        {
            KillPlayer();
        }
        else if(collision.gameObject.CompareTag("Shield"))
        {
            Instantiate(shield, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("NextLevel"))
        {
            var script = gameObject.GetComponent<Player>();
            winScreen.SetActive(true);
            anim.SetTrigger("Win");
            Time.timeScale = 0;
            Destroy(script);
        }
        else if(collider.gameObject.CompareTag("Key"))
        {
            Destroy(collider.gameObject.GetComponent<BoxCollider2D>());
            key = collider.gameObject;
        }
    }

    IEnumerator Kill()
    {
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var script = gameObject.GetComponent<Player>();
        Destroy(spriteRenderer);
        popParticles.SetActive(true);
        yield return new WaitForSeconds(1);
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        Destroy(script);
    }

    public void KillPlayer()
    {
        StartCoroutine(Kill());
    }
}
