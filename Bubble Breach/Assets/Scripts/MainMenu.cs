using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Animator optionsAnimator;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainMenuButtons;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;
        Player.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenOptions()
    { 
        optionsAnimator.SetBool("isOpen", true);
        player.SetActive(false);
        mainMenuButtons.SetActive(false);
    }

    public void CloseOptions()
    { 
        optionsAnimator.SetBool("isOpen", false);
        player.SetActive(true);
        mainMenuButtons.SetActive(true);
        // set options
    }

    public void Quit()
    {
        Application.Quit();
    }
}
