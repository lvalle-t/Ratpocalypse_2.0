// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class DialogueLine : MonoBehaviour
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
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueLine : MonoBehaviour
{
    public TextMeshPro textComponent;
    public string[] lines;
    public float textSpeed;
    private int index = 0;
    public Animator dialogueAnimator;
    private bool StartDialogue = true;
    public GameObject startPlayer;
    public GameObject startMap;

    // Start is called before the first frame update
    void Start()
    {
        // Open the dialogue box initially
        dialogueAnimator.SetTrigger("enter");
        StartDialogue = false;

        // Start typing the first line
        StartCoroutine(TypeLine());
    }

    // Update is called once per frame
    void Update()
    {
        // Check for space key press to advance to the next line
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
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            dialogueAnimator.SetTrigger("exit");
            // Call the StartLevel function to turn on objects
            StartLevel();
        }
    }

    public void StartLevel()
    {
        startPlayer.SetActive(true);
        startMap.SetActive(true);
    }

    // CloseBox method is called to close the dialogue box initially
    public void CloseBox()
    {
        startPlayer.SetActive(false);
        startMap.SetActive(false);
    }
}
