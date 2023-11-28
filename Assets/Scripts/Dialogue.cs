using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshPro textComponent;
    public string[] lines;
    public float textSpeed;
    private int index = 0;
    public Animator dialogueAnimator;
    public GameObject startPlayer;
    public GameObject startMap;

    // Add a skip button
    public KeyCode skipButton = KeyCode.Escape;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDialogueAfterDelay());
    }

    IEnumerator StartDialogueAfterDelay()
    {
        // Wait for a brief moment before triggering the "enter" animation
        yield return new WaitForSeconds(0.5f);

        dialogueAnimator.SetTrigger("enter");

        // Start typing the lines immediately
        StartCoroutine(TypeLine());
    }

    // Update is called once per frame
    void Update()
    {
        // Check for user input to progress through the dialogue
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }

        // Check for skip input
        if (Input.GetKeyDown(skipButton))
        {
            SkipDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        index++;
    }

    void NextLine()
    {
        if (index <= lines.Length - 1)
        {
            // Clear the text and start typing the next line
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // All lines are typed, trigger the "exit" animation and start the level
            textComponent.text = string.Empty;
            dialogueAnimator.SetTrigger("exit");
            StartLevel();
        }
    }

    void SkipDialogue()
    {
        // Skip the dialogue and start the level immediately
        textComponent.text = string.Empty;
        dialogueAnimator.SetTrigger("exit");
        StartLevel();
    }

    void StartLevel()
    {
        startPlayer.SetActive(true);
        startMap.SetActive(true);
    }

    public void CloseBox()
    {
        startPlayer.SetActive(false);
        startMap.SetActive(false);
    }
}
