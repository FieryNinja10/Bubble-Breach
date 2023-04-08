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
        dialogueAnim.Play("Start");
        DisplayNextSentence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DisplayNextSentence()
    {
        if(i >= sentences.Length - 1)
        {
            camera.Follow = player;
            dialogueAnim.Play("End");
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
