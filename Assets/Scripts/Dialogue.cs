// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class Dialogue : MonoBehaviour
// {
//     public TextMeshPro textComponent;
//     public string[] lines;
//     public float textSpeed;
//     private int index = 0;
//     public Animator dialogueAnimator;
//     private bool StartDialogue = true;
//     public GameObject startPlayer;
//     public GameObject startMap;

//     // Start is called before the first frame update

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             if (StartDialogue)
//             {
//                 dialogueAnimator.SetTrigger("enter");
//                 StartDialogue = false;
//             }
//             else
//             {
//                 NextLine();
//             }

//         }
//     }

//     IEnumerator TypeLine()
//     {
//         foreach (char c in lines[index].ToCharArray())
//         {
//             textComponent.text += c;
//             yield return new WaitForSeconds(textSpeed);
//         }
//         index++;
//     }

//     void NextLine()
//     {
//         if (index <= lines.Length - 1)
//         {
//             textComponent.text = string.Empty;
//             StartCoroutine(TypeLine());
//         }
//         else
//         {
//             textComponent.text = string.Empty;
//             dialogueAnimator.SetTrigger("exit");
//             // Call the StartLevel function to turn on objects
//             StartLevel();
//         }
//     }

//     public void StartLevel()
//     {
//         startPlayer.SetActive(true);
//         startMap.SetActive(true);
//     }

//     public void CloseBox()
//     {
//         startPlayer.SetActive(false);
//         startMap.SetActive(false);
//     }
// }



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
