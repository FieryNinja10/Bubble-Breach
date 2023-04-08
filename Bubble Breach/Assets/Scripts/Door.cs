using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    private Animator anim;
    // Start is called before the first frame update

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        if(!isOpen)
        {
            anim.Play("Close");
        }
        else
        {
            anim.Play("Open");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDoor()
    {
        if(!isOpen)
        {
            anim.Play("Open");
            isOpen = true;
        }
        else
        {
            anim.Play("Close");
            isOpen = false;
        }
    }
}
