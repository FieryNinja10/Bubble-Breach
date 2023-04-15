using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private string[] sentences, names;
    [SerializeField] private Transform[] lookAtDialogue;
    [SerializeField] private Animator dialogueAnim;
    [SerializeField] private TMP_Text dialogueText, dialogueName;
    [SerializeField] private CinemachineVirtualCamera camera;
    [SerializeField] private Transform player;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        dialogueAnim.SetTrigger("StartDialogue");
        DisplayNextSentence();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    // Menus

        // Pause Menu

    public void PauseMenu() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

        // Options

    public void OpenOptions() {
        optionsMenu.SetActive(true);
    }

        // Lose Menu

    public void LoseScreen() {
        loseScreen.SetActive(true);
    }

        // Win Menu

    public void WinScreen() {
        winScreen.SetActive(true);
    }

    // Scene

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Dialogue

    public void DisplayNextSentence()
    {
        if(i >= sentences.Length - 1)
        {
            camera.Follow = player;
            dialogueAnim.SetTrigger("EndDialogue");
            Player.canMove = true;
            return;
        }

        
        camera.Follow = lookAtDialogue[i];
        dialogueName.text = names[i];
        StopAllCoroutines();
        StartCoroutine(DialogueTextAnim(sentences[i]));
        i++;
    }

    private IEnumerator DialogueTextAnim(string toType)
    {
        dialogueText.text = "";

        foreach (char letter in toType.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
}
