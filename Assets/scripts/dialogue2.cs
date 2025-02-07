using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dialogue2 : MonoBehaviour
{ public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;

    private Queue<string> sentences;
    private bool isDialogueActive = false;

    void Start()
    {
        sentences = new Queue<string>();
        
        FindObjectOfType<dialogue2>().StartDialogue(new string[]
        {
            "Good work out there. I didnt expect you to make it back alive. But you did it.",
            "So for the next missi--- SHIT!! I think he tapped our comms. He knows what we are doing.",
            "BEHIND YOU!!!. Shit. He sent out the big gun to finish us off.",
            "What even is that thing? Hard to believe it was human once.",
            "You cant kill it. You have to run away. ",
            "BUT WE ARE AMUZON. WE NEVER STOP. WHEN THE WORLD IS FALLING APART.",
            "You have to deliver the packages while being on the run. I know its sounds impossible but I believe you can do it.  ",
            "I believe you have the power to finish him off for good. The road will take us to him. ",
            "NOW GO! I have faith in you.",
            "Press SPACE to continue..."
                    });
    }

    public void StartDialogue(string[] dialogueLines)
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        sentences.Clear();

        foreach (string line in dialogueLines)
        {
            sentences.Enqueue(line);
        }

        DisplayNextSentence();
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f); // Adjust for typing speed
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false); // Hide the dialogue box

        // Load the next scene (change "GameLevel" to your actual level scene name)
        SceneManager.LoadScene("level1");
    }
}
