using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonScript : MonoBehaviour
{
    [SerializeField] private List<Door> doors;
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PressedButton();
        }
    }

    void PressedButton()
    {
        anim.Play("Pressed");

        foreach (Door door in doors)
        {
            door.ToggleDoor();
        }
    }
}
